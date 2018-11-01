using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonColorChange : ButtonAnim
{
    [BoxGroup("Fill")] public Timer fillAnimationTime = new Timer(0.5f);
    [BoxGroup("Fill")] public Image buttonFill;
    [BoxGroup("Fill")] public Color primaryColor = Colors.White;
    [BoxGroup("Fill")] public Color HoverColor = Colors.RedPurple;
    [BoxGroup("Fill")] public Color PressColor = Colors.RedRYB;
    [BoxGroup("Fill")] public EasingEquationsType animEquation = EasingEquationsType.EaseInCubic;

    private Color changingTo;
    private Color changingFrom;

    protected Float01 fillProgress;

    protected Color ChangingTo
    {
        get => changingTo;

        set
        {

            if (!Colors.Compare(ChangingTo, value))
            {
                fillProgress = 0f;
                changingFrom = changingTo;
                changingTo = value;
                fillAnimationTime.Reset();
            }
        }
    }

    protected virtual void Awake()
    {
        changingTo = primaryColor;
        if (!buttonFill)
            buttonFill = GetComponent<Image>();
    }

    protected virtual void ChangeFillColor()
    {


        if (pressing)
        {
            ChangingTo = PressColor;
        }
        else if (hovering)
        {
            ChangingTo = HoverColor;
        }
        else
        {
            ChangingTo = primaryColor;
        }

        if (buttonFill)
        {
            if (!fillAnimationTime.isFinished)
            {
                var t = fillAnimationTime.Counter / fillAnimationTime.Time;
                //buttonFill.color = LerpToColor(changingFrom, changingTo, t, EasingEquations.GetEquation(animEquation));
                buttonFill.color = Color.Lerp(changingFrom, ChangingTo, t);
                fillAnimationTime.Update();
            }
        }

    }

    protected virtual Color LerpToColor(Color startColor, Color endColor, Float01 value, Func<float, float, float, float> equation)
    {
        return (endColor - startColor) * value + startColor;

    }


    public override void OnPointerDown(PointerEventData eventData)
    {
        pressing = true;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        pressing = false;
    }

    private void Reset()
    {
        buttonFill = GetComponent<Image>();
    }
}
