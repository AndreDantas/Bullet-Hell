
using Sirenix.OdinInspector;
using UnityEngine;
[System.Serializable]
public class SpawnMovementLinear : SpawnMovement
{
    [LabelWidth(200)] public bool scaleToScreenSize;
    public Vector2 startPoint;
    public Vector2 endPoint;
    public float moveTime = 1f;
    public EasingEquationsType moveEquation = EasingEquationsType.EaseInOutQuad;

    public override Tweener SetSpawnObjectMovement(GameObject obj)
    {
        Vector2 start, end;
        if (scaleToScreenSize)
        {
            var uq = new UnitaryQuadrant(UtilityFunctions.ScreenWidth, UtilityFunctions.ScreenHeight);
            start = uq.GetPoint(startPoint);
            end = uq.GetPoint(endPoint);
        }
        else
        {
            start = startPoint;
            end = endPoint;
        }

        obj.transform.position = start;
        return obj.transform.MoveTo(end, moveTime, EasingEquations.GetEquation(moveEquation));
    }
}