using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public abstract class Effect : MonoBehaviour
{
    [ShowInInspector, PropertyOrder(-1), ReadOnly]
    public bool inProgress { get; internal set; }

    protected virtual void OnDisable()
    {
        EndEffect();
    }

    public virtual void StartEffect()
    {
        if (inProgress)
            EndEffect();
    }

    public abstract void UpdateEffect();

    public abstract void EndEffect();
}
