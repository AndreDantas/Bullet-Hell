using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Stats
{
    [Serializable]
    public class Stat
    {

        public float BaseValue;
        protected float lastBaseValue = float.MinValue;

        protected readonly List<StatModifier> statModifiers;
        public readonly ReadOnlyCollection<StatModifier> StatModifiers;

        protected bool isDirty = true;
        protected float _value;

        public float Value
        {
            get
            {
                if (isDirty || lastBaseValue != BaseValue)
                {
                    lastBaseValue = BaseValue;
                    _value = CalculateFinalValue();
                    isDirty = false;
                }
                return _value;
            }
        }



        public Stat()
        {
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
        }

        public Stat(float baseValue) : this()
        {
            BaseValue = baseValue;
        }

        public virtual void AddModifier(StatModifier mod)
        {
            isDirty = true;
            statModifiers.Add(mod);
            statModifiers.Sort(CompareModifierOrder);
        }

        public virtual bool RemoveModifier(StatModifier mod)
        {
            if (statModifiers.Remove(mod))
            {
                isDirty = true;
                return true;
            }

            return false;
        }

        public virtual bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;

            for (int i = statModifiers.Count - 1; i >= 0; i--)
            {
                if (statModifiers[i].Source == source)
                {
                    isDirty = true;
                    didRemove = true;
                    statModifiers.RemoveAt(i);
                }
            }
            return didRemove;
        }

        protected virtual float CalculateFinalValue()
        {
            var finalValue = new StatModHelper(BaseValue);

            for (int i = 0; i < statModifiers.Count; i++)
            {
                finalValue = statModifiers[i].Modify(finalValue);
            }

            return UtilityFunctions.RoundDown(finalValue.value, 1);
        }

        protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
        {
            if (a.Order < b.Order)
                return -1;
            else if (a.Order > b.Order)
                return 1;
            return 0;
        }
    }

    public struct StatModHelper
    {
        public float value;
        public List<StatModifier> statsMods;

        public StatModHelper(float value) : this()
        {
            this.value = value;
            statsMods = new List<StatModifier>();
        }

        public StatModHelper(float value, List<StatModifier> statsMods)
        {
            this.value = value;
            this.statsMods = statsMods;
        }
    }
}
