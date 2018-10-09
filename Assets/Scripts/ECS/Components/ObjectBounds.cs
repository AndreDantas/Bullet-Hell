using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Sirenix.OdinInspector;
public class ObjectBounds : MonoBehaviour
{
    public bool SetToScreenSizeOnAwake = true;
    [ShowIf("SetToScreenSizeOnAwake")]
    [PropertyRange(0f, 100f)]
    public float ScreenCoverage = 100f;
    [DisableIf("SetToScreenSizeOnAwake")]
    public Bounds bounds;


    private void Awake()
    {
        if (SetToScreenSizeOnAwake)
            bounds.extents = new Vector3((UtilityFunctions.ScreenWidth / 2f) * ScreenCoverage / 100f,
                                            (UtilityFunctions.ScreenHeight / 2f) * ScreenCoverage / 100f, bounds.extents.z);

    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (!SetToScreenSizeOnAwake)
            UtilityFunctions.GizmosDrawBounds(bounds);
        else
        {
            Bounds b = new Bounds();

            var screenSize = Handles.GetMainGameViewSize();
            float width = UtilityFunctions.ScreenHeight * screenSize.x / screenSize.y;

            b.extents = new Vector3((width / 2f) * ScreenCoverage / 100f,
                                            (UtilityFunctions.ScreenHeight / 2f) * ScreenCoverage / 100f, bounds.extents.z);
            UtilityFunctions.GizmosDrawBounds(b);
        }
    }
#endif
}
