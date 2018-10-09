using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
[DisallowMultipleComponent]
public class Faction : MonoBehaviour
{

    public enum Type
    {
        Player = 0,
        Enemy = 1
    }

    public Type Value;
}
