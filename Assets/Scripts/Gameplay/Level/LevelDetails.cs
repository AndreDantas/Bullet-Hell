using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "LevelDetails", menuName = "Level/New Level", order = 1)]
[System.Serializable]
public class LevelDetails : ScriptableObject
{

    public List<WaveDetails> waves = new List<WaveDetails>();

}
