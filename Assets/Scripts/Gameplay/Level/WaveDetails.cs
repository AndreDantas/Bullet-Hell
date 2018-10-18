using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;

[System.Serializable]
public class WaveDetails
{
    public List<SpawnDetails> spawns = new List<SpawnDetails>();
    public float waveDelay;
}
