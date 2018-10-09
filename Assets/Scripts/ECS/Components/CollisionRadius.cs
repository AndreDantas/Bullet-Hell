using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class CollisionRadius : MonoBehaviour
{

    [SerializeField, HideInInspector]
    private float value = 1f;
    public Vector2 Offset;
    public bool resizeToScale = false;
    [DisableIf("resizeToScale")]
    [ShowInInspector]
    public float Value { get => resizeToScale ? (transform.lossyScale.x + transform.lossyScale.y) / 2 * scaleMultiplier : value; set => this.value = value; }
    [ShowIf("resizeToScale")]
    public float scaleMultiplier = 1f;
    private void OnDrawGizmosSelected()
    {
        UtilityFunctions.GizmosDrawCircle((Vector2)transform.position + Offset, Value, Value);
    }
}
