using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class MoveRandomAreaSmoothDetails : MovementDetails
{
    public override void AddMovementComponent(GameObject obj)
    {
        throw new System.NotImplementedException();
    }
}
[System.Serializable]
public class MoveRandomAreaSmooth : Movement
{
    public float moveTime = 5f;

    public bool scaleToScreenSize;
    public Bounds area;
    public EasingEquationsType moveEquation = EasingEquationsType.EaseInOutCubic;
    [Range(3, 30)]
    public int pathPoints = 5;
    [Range(10, 50)]
    public int curvePoints = 30;

    protected BezierCurve path;

    public override void Move()
    {

        if (!active)
            return;

        if (!isMoving)
        {
            pathPoints = UtilityFunctions.ClampMin(pathPoints, 3);
            List<Vector3> points = new List<Vector3>();
            points.Add(transform.position);

            Bounds b;
            if (!scaleToScreenSize)
            {
                b = area;
            }
            else
            {
                var w = UtilityFunctions.ScreenWidth;
                var h = UtilityFunctions.ScreenHeight;

                b = new Bounds(UnitaryQuadrant.Screen.GetPoint(area.center), new Vector3(w * area.size.x, h * area.size.y));
            }

            for (int i = 0; i < pathPoints - 1; i++)
            {
                points.Add(b.RandomPoint());
            }

            path = new BezierCurve(points, curvePoints);

            isMoving = true;
            var t = transform.MoveInBezierCurve(path, moveTime, EasingEquations.GetEquation(moveEquation));
            t.destroyOnDisable = true;
            t.easingControl.completedEvent += (object sender, System.EventArgs args) => isMoving = false;


        }

    }

    public override void SetMovement(MovementDetails details)
    {
        throw new System.NotImplementedException();
    }

    private void OnDrawGizmosSelected()
    {
        if (!scaleToScreenSize)
            UtilityFunctions.GizmosDrawBounds(area);
        else
        {
            var w = UtilityFunctions.ScreenWidth;
            var h = UtilityFunctions.ScreenHeight;

            Bounds b = new Bounds(UnitaryQuadrant.Screen.GetPoint(area.center), new Vector3(w * area.size.x, h * area.size.y));

            UtilityFunctions.GizmosDrawBounds(b);
        }

        UtilityFunctions.GizmosDrawBezierCurve(path);
    }
}
