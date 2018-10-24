using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveDetails
{
    public bool skipWave;
    public float waveDelay;
    [DisableIf("skipWave")]
    public List<SpawnDetails> spawns = new List<SpawnDetails>();

}
