using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class DamageShakeEffect : Effect
{


    public Timer effectTimer = new Timer(0.05f);
    public float effectPower = 0.1f;
    Vector3 movePos;

    Vector3 RandomPos()
    {
        var randomPos = Random.insideUnitCircle;
        return new Vector3(randomPos.x * effectPower * transform.localScale.x, randomPos.y * effectPower * transform.localScale.y);
    }

    public override void StartEffect()
    {
        base.StartEffect();

        effectTimer.Reset();
        inProgress = true;
        movePos = RandomPos();

        transform.localPosition += movePos;
    }

    public override void UpdateEffect()
    {

        transform.localPosition -= movePos;
        movePos = RandomPos();
        transform.localPosition += movePos;

        effectTimer.Update();
        if (effectTimer.isFinished)
            EndEffect();

    }

    public override void EndEffect()
    {

        inProgress = false;
        transform.localPosition -= movePos;
        effectTimer.Reset();

    }
}
