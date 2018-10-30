using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;
public class ChangeColorOnHover : ChangeColor, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{

    protected bool hovering;
    protected bool selected;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        selected = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        selected = false;
    }

    public override void ColorUpdate()
    {

        if (hovering || selected)
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
}
