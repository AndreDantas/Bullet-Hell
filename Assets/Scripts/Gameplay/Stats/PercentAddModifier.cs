using Sirenix.OdinInspector;
using Stats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PercentAddModifier : StatModifier
{
    public PercentAddModifier(float value) : base(value)
    {
    }

    public PercentAddModifier(float value, int order) : base(value, order)
    {
    }

    public PercentAddModifier(int order, float value, object source) : base(order, value, source)
    {
    }

    public override StatModHelper Modify(StatModHelper stat)
    {
        var percent = 0f;
        for (int i = 0; i < stat.statsMods.Count; i++)
        {
            if (stat.statsMods[i] is PercentAddModifier)
                percent += stat.statsMods[i].Value;
        }

        float statOldValue = UtilityFunctions.ReversePercentage(stat.value, percent);

        stat.value += (stat.value * ((percent + Value) / 100f));

        return stat;
    }
}
