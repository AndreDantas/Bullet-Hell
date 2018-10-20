using Sirenix.OdinInspector;
using UnityEngine;
[System.Serializable]
public class SpawnDetails
{
    [InlineEditor(InlineEditorModes.SmallPreview), AssetsOnly]
    public GameObject enemyPrefab;
    public float spawnDelay;

    [BoxGroup("Spawn Movement")] public bool scaleToScreenSize;
    [BoxGroup("Spawn Movement")] public Vector2 startPoint;
    [BoxGroup("Spawn Movement")] public Vector2 endPoint;
    [BoxGroup("Spawn Movement")] public float moveTime = 1f;
    [BoxGroup("Spawn Movement")] public EasingEquationsType moveEquation = EasingEquationsType.EaseInOutQuad;

}