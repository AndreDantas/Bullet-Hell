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
    protected BezierCurve path;

    public override void Move()
    {

        if (!active)
            return;

        if (!isMoving)
        {

            Vector3 destination1, destination2;
            if (!scaleToScreenSize)
            {
                destination2 = area.RandomPoint();
                destination1 = area.RandomPoint();
            }
            else
            {
                var w = UtilityFunctions.ScreenWidth;
                var h = UtilityFunctions.ScreenHeight;

                Bounds b = new Bounds(UnitaryQuadrant.Screen.GetPoint(area.center), new Vector3(w * area.size.x, h * area.size.y));

                destination2 = b.RandomPoint();
                destination1 = b.RandomPoint();
            }
            path = new BezierCurve(new List<Vector3> { transform.position, destination1, destination2 });

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
