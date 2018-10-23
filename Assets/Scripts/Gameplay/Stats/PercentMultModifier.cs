
[System.Serializable]
public class PercentMultModifier : Stats.StatModifier
{
    public PercentMultModifier(float value, int order) : base(value, order)
    {
    }

    public PercentMultModifier(int order, float value, object source) : base(order, value, source)
    {
    }

    public override Stats.StatModHelper Modify(Stats.StatModHelper stat)
    {
        stat.value += (stat.value * (Value / 100f));

        return stat;
    }
}

