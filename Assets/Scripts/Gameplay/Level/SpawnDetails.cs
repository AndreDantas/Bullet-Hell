using Sirenix.OdinInspector;
using UnityEngine;
[System.Serializable]
public class SpawnDetails
{
    public GameObject enemyPrefab;
    public float spawnDelay;

    [BoxGroup("Spawn Movement")] public Vector2 startPoint;
    [BoxGroup("Spawn Movement")] public Vector2 moveToPoint;
    [BoxGroup("Spawn Movement")] public float moveTime = 1f;
    [BoxGroup("Spawn Movement")] public EasingEquationsType moveEquation = EasingEquationsType.EaseInCubic;

}