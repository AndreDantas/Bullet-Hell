using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class DamageColorEffect : Effect
{
    [Required(InfoMessageType.Warning)]
    public SpriteRenderer sr;
    public Color damageColor = Color.red;
    protected Color originColor;

    private void OnEnable()
    {
        if (inProgress)
            EndEffect();
        originColor = sr?.color ?? Color.white;
    }

    public override void StartEffect()
    {
        base.StartEffect();

        if (!sr)
            return;
        inProgress = true;
        originColor = sr.color;
    }

    public override void UpdateEffect()
    {
        if (!sr)
            return;

    }

    public override void EndEffect()
    {
        if (!sr)
            return;
        inProgress = false;
    }
}
