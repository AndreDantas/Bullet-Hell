using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public abstract class MovementDetails
{
    public abstract void AddMovementComponent(GameObject obj);
}

public abstract class Movement : MonoBehaviour
{

    public bool active = true;
    protected bool isMoving;
    public abstract void Move();

    protected virtual void OnDisable()
    {
        isMoving = false;
    }

    public abstract void SetMovement(MovementDetails details);
}
