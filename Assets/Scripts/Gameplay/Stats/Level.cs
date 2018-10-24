using Sirenix.OdinInspector;
using Stats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Stats
{
    [System.Serializable]
    public class Level
    {
        public const int MAX_LEVEL = 99;
        public const int MIN_LEVEL = 1;

        private int value = 1;
        [ShowInInspector, PropertyOrder(-1)] public int Value { get => value; set => this.value = Mathf.Clamp(value, MIN_LEVEL, MAX_LEVEL); }


        [Range(1, 100000), BoxGroup("Experience")] public int BaseXP = 100;
        [ShowInInspector, BoxGroup("Experience"), ReadOnly] public int TotalXP { get; private set; }
        [ProgressBar(0, "XpToNextLevel"), BoxGroup("Experience")] public int CurrentXP;

        public int XpToNextLevel { get { return (growthFormula ?? new ExponentialGrowth()).XP_ToNextLevel(Value + 1, BaseXP); } }

        [ShowInInspector, BoxGroup("Experience")]
        public bool CanLevelUp
        {
            get
            {
                return Value == MAX_LEVEL ? false :
                                            CurrentXP >= (growthFormula ?? new ExponentialGrowth()).XP_ToNextLevel(Value + 1, BaseXP);
            }
        }

        public GrowthFormula growthFormula = new ExponentialGrowth();

        public Level() : this(1, new ExponentialGrowth())
        {
        }

        public Level(int value)
        {
            Value = value;
            CurrentXP = 0;

        }

        public Level(int value, GrowthFormula growthFormula) : this(value)
        {
            this.growthFormula = growthFormula;
        }

        public delegate void OnLevelUpEventHandler(Level level);
        public event OnLevelUpEventHandler OnLevelUp;

        public virtual void AddXP(int xp)
        {
            if (Value == MAX_LEVEL)
                return;

            xp = UtilityFunctions.ClampMin(xp, 0);
            CurrentXP += xp;
            TotalXP += xp;
        }

        public virtual bool LevelUp()
        {
            if (Value + 1 > MAX_LEVEL)
                return false;

            bool levelUp = false;
            var formula = growthFormula ?? new ExponentialGrowth();

            var nextLevelXP = formula.XP_ToNextLevel(Value + 1, BaseXP);

            while (CurrentXP >= nextLevelXP || Value + 1 > MAX_LEVEL)
            {
                CurrentXP -= nextLevelXP;
                Value++;
                nextLevelXP = formula.XP_ToNextLevel(Value + 1, BaseXP);
                levelUp = true;
            }

            if (levelUp)
                OnLevelUp?.Invoke(this);

            return levelUp;
        }


    }

    public interface GrowthFormula { int XP_ToNextLevel(int level, int baseXP); }

    [System.Serializable]
    public class ExponentialGrowth : GrowthFormula
    {
        public float exponent = 1.5f;

        public ExponentialGrowth()
        {
        }

        public ExponentialGrowth(float exponent)
        {
            this.exponent = exponent;
        }

        public int XP_ToNextLevel(int level, int baseXP)
        {
            return (int)Mathf.Floor(baseXP * (Mathf.Pow(level, exponent)));
        }
    }

}
