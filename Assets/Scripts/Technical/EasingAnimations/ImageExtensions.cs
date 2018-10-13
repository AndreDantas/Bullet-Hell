using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System;
namespace EasingAnimations
{
    public static class ImageExtensions
    {

        #region SpriteRenderer

        public static Tweener ChangeColorTo(this SpriteRenderer sr, Color color)
        {
            return ChangeColorTo(sr, color, Tweener.DefaultDuration);
        }
        public static Tweener ChangeColorTo(this SpriteRenderer sr, Color color, float duration)
        {
            return ChangeColorTo(sr, color, duration, Tweener.DefaultEquation);
        }

        public static Tweener ChangeColorTo(this SpriteRenderer sr, Color color, float duration, Func<float, float, float, float> equation)
        {
            SpriteRendererTweener tweener = sr.gameObject.AddComponent<SpriteRendererTweener>();
            tweener.startColor = sr.color;
            tweener.endColor = color;
            tweener.easingControl.duration = duration;
            tweener.easingControl.equation = equation;
            tweener.easingControl.Play();
            return tweener;
        }
        #endregion

        #region Image
        public static Tweener ChangeColorTo(this Image i, Color color)
        {
            return ChangeColorTo(i, color, Tweener.DefaultDuration);
        }
        public static Tweener ChangeColorTo(this Image i, Color color, float duration)
        {
            return ChangeColorTo(i, color, duration, Tweener.DefaultEquation);
        }

        public static Tweener ChangeColorTo(this Image i, Color color, float duration, Func<float, float, float, float> equation)
        {
            ImageColorTweener tweener = i.gameObject.AddComponent<ImageColorTweener>();
            tweener.startColor = i.color;
            tweener.endColor = color;
            tweener.easingControl.duration = duration;
            tweener.easingControl.equation = equation;
            tweener.easingControl.Play();
            return tweener;
        }


        #endregion
    }
}
