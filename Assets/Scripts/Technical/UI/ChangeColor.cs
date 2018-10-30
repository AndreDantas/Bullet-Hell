using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;
public abstract class ChangeColor : MonoBehaviour
{
    public bool active = true;
    public MaskableGraphic graphic;
    public Timer animTime = new Timer(0.5f);
    public Color StartColor = Color.white;
    public Color EndColor = Color.red;

    protected virtual void Update()
    {
        if (active)
            ColorUpdate();
    }

    public abstract void ColorUpdate();

    public virtual void ResetColor()
    {
        if (graphic)
            graphic.color = StartColor;
        animTime.Reset();
    }
}
