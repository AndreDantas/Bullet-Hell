using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class DeathEffect
{

    public GameObject effectPrefab;

    public bool InProgress { get; private set; }

    public virtual void ActivateEffect()
    {
       
    }

    private void OnDisable()
    {
        InProgress = false;
    }
}
