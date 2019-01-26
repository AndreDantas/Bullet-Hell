using Sirenix.OdinInspector;
using UnityEngine;
[System.Serializable]
public class SpawnMovementTypeSelect
{
    public enum SpawnMovementType { Linear, BezierCurve }

    [SerializeField, HideInInspector]
    private SpawnMovementType movementType;

    [ShowInInspector, PropertyOrder(-1)]
    public SpawnMovementType MovementType
    {
        get => movementType;
        set
        {
            movementType = value;
            SetMovement();
        }
    }

    protected SpawnMovement Movement
    {
        get
        {
            SetMovement();
            return movement;
        }
        set => movement = value;
    }

    private SpawnMovement movement;

    [ShowIf("MovementType", SpawnMovementType.Linear)] public SpawnMovementLinear spawnMovementLinear = new SpawnMovementLinear();
    [ShowIf("MovementType", SpawnMovementType.BezierCurve)] public SpawnMovementBezier spawnMovementBezier = new SpawnMovementBezier();

    private void SetMovement()
    {
        switch (MovementType)
        {
            case SpawnMovementType.Linear:
                Movement = spawnMovementLinear;
                break;
            case SpawnMovementType.BezierCurve:
                Movement = spawnMovementBezier;
                break;
            default:
                break;
        }
    }

    public SpawnMovement GetMovement()
    {
        return Movement;
    }
}
[System.Serializable]
public class SpawnDetails
{

    public float spawnDelay;

    [ValidateInput("EnemyOnly", "The prefab needs to have a 'Enemy' component.", InfoMessageType.Warning)]
    [InlineEditor(InlineEditorModes.LargePreview), AssetsOnly]
    public GameObject enemyPrefab;

    [SerializeField, BoxGroup("Enemy's Movement")]
    public MovementTypeSelect MovementType;

    [BoxGroup("Spawn Movement")] public SpawnMovementTypeSelect spawnMovement = new SpawnMovementTypeSelect();


    private bool EnemyOnly(GameObject obj)
    {
        return obj.CheckForComponent<Enemy>();
    }
}