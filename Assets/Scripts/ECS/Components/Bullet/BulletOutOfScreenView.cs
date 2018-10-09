using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class BulletOutOfScreenView : MonoBehaviour
{

    public Bounds bounds
    {
        get
        {
            var b = new Bounds();
            b.extents = new Vector3((UtilityFunctions.ScreenWidth / 2f) * 1.1f,
                       (UtilityFunctions.ScreenHeight / 2f) * 1.1f, 0);
            return b;
        }
    }
}
