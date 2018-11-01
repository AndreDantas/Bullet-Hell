using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthToken : HealthToken
{
    public Image Outline;
    public Image Fill;

    protected Animator anim;

    private void Awake()
    {
        anim = Fill?.GetComponent<Animator>();
    }

    public override void DamageAnim()
    {
        base.DamageAnim();
        if (!Fill)
            return;

        if (anim)
            anim.Play("HealthDamaged");
    }

    public override void HealAnim()
    {
        base.HealAnim();

        if (!Fill)
            return;

        if (anim)
            anim.Play("HealthHeal");
    }

}
