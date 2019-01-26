using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public abstract class SpawnMovement
{
    public abstract Tweener SetSpawnObjectMovement(GameObject obj);
}