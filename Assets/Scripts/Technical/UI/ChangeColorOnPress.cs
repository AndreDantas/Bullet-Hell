using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ChangeColorOnPress : ChangeColor, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool NeedsPointerOnTop = false;
    protected bool pressing;
    protected bool hovering;
    public override void ColorUpdate()
    {
        if ((pressing && hovering) || (pressing && !NeedsPointerOnTop))
        {
            animTime.Update();
        }
        else
        {
            animTime.Reverse();
        }

        if (graphic)
        {
            var t = animTime.Counter / animTime.Time;
            graphic.color = Color.Lerp(StartColor, EndColor, t);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressing = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }
}
