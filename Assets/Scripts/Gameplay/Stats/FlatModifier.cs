
[System.Serializable]
public class FlatModifier : Stats.StatModifier
{
    public FlatModifier(float value, int order) : base(value, order)
    {
    }

    public FlatModifier(int order, float value, object source) : base(order, value, source)
    {
    }

    public override Stats.StatModHelper Modify(Stats.StatModHelper stat)
    {
        stat.value += Value;
        stat.statsMods.Add(this);
        return stat;
    }
}

