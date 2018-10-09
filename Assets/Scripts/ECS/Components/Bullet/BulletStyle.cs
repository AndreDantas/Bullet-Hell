using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class BulletStyle : MonoBehaviour
{

    public Color Color = Color.red;
    public Float01 transparency = 1f;
    public Sprite Sprite;

    private void OnDisable()
    {
        transparency = 1f;
    }
}
