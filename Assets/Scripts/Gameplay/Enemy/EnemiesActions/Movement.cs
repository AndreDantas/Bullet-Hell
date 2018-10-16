using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public abstract class Movement : MonoBehaviour
{
    public float moveTime = 5f;
    public bool active = true;
    protected bool isMoving;
    public abstract void Move();

}
