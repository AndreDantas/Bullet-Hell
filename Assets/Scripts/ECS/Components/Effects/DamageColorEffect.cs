using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class DamageColorEffect : Effect
{

    [SerializeField, HideInInspector]
    private SpriteRenderer _sr;
    [Required(InfoMessageType.Warning), ShowInInspector, PropertyOrder(-1)]
    public SpriteRenderer spriteRenderer { get { return _sr; } set { originColor = value.color; _sr = value; } }

    public float flashTime = 0.2f;
    public Color damageColor = Color.red;
    protected Color originColor;
    private bool fadeIn;
    private float elapsedTime;

    private void OnEnable()
    {

        originColor = spriteRenderer?.color ?? Color.white;
    }

    public override void StartEffect()
    {

        if (!spriteRenderer)
            return;

        inProgress = true;
        fadeIn = true;
    }

    public override void UpdateEffect()
    {
        if (!spriteRenderer)
            return;
        if (fadeIn)
        {
            elapsedTime += Time.deltaTime;

            var i = elapsedTime / (flashTime / 2f);

            spriteRenderer.color = Color.Lerp(originColor, damageColor, i);

            if (i >= 1)
                fadeIn = false;

        }
        else
        {
            elapsedTime -= Time.deltaTime;

            var i = elapsedTime / (flashTime / 2f);

            spriteRenderer.color = Color.Lerp(originColor, damageColor, i);

            if (i <= 0)
            {
                elapsedTime = 0f;
                inProgress = false;
            }


        }
    }

    public override void EndEffect()
    {

        if (!spriteRenderer)
            return;
        inProgress = false;
        spriteRenderer.color = originColor;
    }

    private void Reset()
    {
        var sr = GetComponent<SpriteRenderer>();
        if (sr)
            this.spriteRenderer = sr;
    }
}
