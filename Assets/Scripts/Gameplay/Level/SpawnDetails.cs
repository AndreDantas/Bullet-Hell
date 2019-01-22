using Sirenix.OdinInspector;
using UnityEngine;
[System.Serializable]
public class SpawnDetails
{
    public float spawnDelay;

    [HorizontalGroup("Split", width: 0.5f)]
    [ValidateInput("EnemyOnly", "The prefab needs to have a 'Enemy' component.", InfoMessageType.Warning)]
    [BoxGroup("Split/Enemy"), InlineEditor(InlineEditorModes.SmallPreview), AssetsOnly]
    public GameObject enemyPrefab;

    [BoxGroup("Split/Spawn Movement"), LabelWidth(150)] public bool scaleToScreenSize;
    [BoxGroup("Split/Spawn Movement"), LabelWidth(70)] public Vector2 startPoint;
    [BoxGroup("Split/Spawn Movement"), LabelWidth(70)] public Vector2 endPoint;
    [BoxGroup("Split/Spawn Movement"), LabelWidth(100)] public float moveTime = 1f;
    [BoxGroup("Split/Spawn Movement"), LabelWidth(100)] public EasingEquationsType moveEquation = EasingEquationsType.EaseInOutQuad;

    [SerializeField]
    public MovementTypeSelect MovementType;

    private bool EnemyOnly(GameObject obj)
    {
        return obj.CheckForComponent<Enemy>();
    }
}