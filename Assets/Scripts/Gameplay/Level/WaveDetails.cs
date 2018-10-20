using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;

[System.Serializable]
public class WaveDetails
{
    public bool skipWave;
    public float waveDelay;
    public List<SpawnDetails> spawns = new List<SpawnDetails>();

}
