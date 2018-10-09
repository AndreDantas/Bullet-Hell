using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class BulletMovement : MonoBehaviour
{

    public float Speed = 1;
    public Vector2 Direction;
    public bool changeTransformOrientation = true;

    [ShowIf("changeTransformOrientation")]
    public float AngleOffset;

    public void SetValues(BulletMovement other)
    {
        Speed = other.Speed;
        Direction = other.Direction;
        AngleOffset = other.AngleOffset;
        changeTransformOrientation = other.changeTransformOrientation;
    }
}
