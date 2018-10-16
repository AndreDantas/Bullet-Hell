using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class CollisionRadius : MonoBehaviour
{

    [SerializeField, HideInInspector]
    private Vector2 value = new Vector2(1f, 1f);
    [BoxGroup("Radius")]
    public Vector2 Offset;
    [BoxGroup("Radius")]
    public bool resizeToScale = false;

    [DisableIf("resizeToScale"), ShowInInspector, BoxGroup("Radius")]
    public Vector2 Value { get => resizeToScale ? (Vector2)transform.lossyScale * scaleMultiplier : value; set => this.value = value; }
    [ShowIf("resizeToScale"), BoxGroup("Radius")]
    public Vector2 scaleMultiplier = new Vector2(1f, 1f);

    [SerializeField, HideInInspector]
    private float angle = 0f;

    [BoxGroup("Angle")]
    public bool useTransformRotation = false;
    [DisableIf("useTransformRotation"), ShowInInspector, BoxGroup("Angle")]
    public float Angle { get => useTransformRotation ? transform.rotation.eulerAngles.z : angle; set => this.angle = value; }

    private void OnDrawGizmosSelected()
    {
        UtilityFunctions.GizmosDrawEllipse((Vector2)transform.position + Offset, Value.x, Value.y, Angle);
    }
}
