using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class SpawnMovementBezier : SpawnMovement
{
    [LabelWidth(200)] public bool scaleToScreenSize;
    public BezierCurve curve = new BezierCurve();
    public float moveTime = 1f;
    public EasingEquationsType moveEquation = EasingEquationsType.EaseInOutQuad;

    public override Tweener SetSpawnObjectMovement(GameObject obj)
    {
        BezierCurve b = new BezierCurve();
        if (scaleToScreenSize)
        {
            var uq = new UnitaryQuadrant(UtilityFunctions.ScreenWidth, UtilityFunctions.ScreenHeight);
            var list = curve.lineControlPoints;
            for (int i = 0; i < list.Count; i++)
            {
                b.lineControlPoints.Add(uq.GetPoint(list[i]));
            }
        }
        else
        {
            b = curve;
        }
        if (b.lineControlPoints.Count > 0)
            obj.transform.position = b.lineControlPoints[0];
        return obj.transform.MoveInBezierCurve(b, moveTime, EasingEquations.GetEquation(moveEquation));
    }
}