namespace Stats
{
    [System.Serializable]
    public abstract class StatModifier
    {
        public readonly int Order;
        public readonly float Value;
        public readonly object Source;

        protected StatModifier(int order, float value, object source)
        {
            Order = order;
            Value = value;
            Source = source;
        }

        public StatModifier(float value, int order)
        {
            Value = value;
            Order = order;
        }

        protected StatModifier(float value)
        {
            Value = value;
        }



        public abstract StatModHelper Modify(StatModHelper stat);
    }
}