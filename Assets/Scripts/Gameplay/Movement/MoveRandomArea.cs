using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class MoveRandomArea : Movement
{
    public bool scaleToScreenSize;
    public Bounds area;
    public Timer waitTime = new Timer(0.5f, true);
    public EasingEquationsType moveEquation = EasingEquationsType.EaseInOutCubic;
    protected Vector2 destination;
    protected UnitaryQuadrant uq;
    private void Start()
    {
        uq = new UnitaryQuadrant(Vector2.zero, UtilityFunctions.ScreenWidth, UtilityFunctions.ScreenHeight);
    }
    public override void Move()
    {
        if (!active)
            return;

        if (!isMoving)
        {
            if (!waitTime.isFinished)
            {
                waitTime.Update();
            }
            else
            {
                if (!scaleToScreenSize)
                    destination = area.RandomPoint();
                else
                    destination = uq.GetPoint(area.RandomPoint());

                isMoving = true;
                var t = transform.MoveTo(destination, moveTime, EasingEquations.GetEquation(moveEquation));
                t.destroyOnDisable = true;
                t.easingControl.completedEvent += (object sender, System.EventArgs args) => isMoving = false;
                waitTime.Reset();
            }
        }

    }


    private void OnDrawGizmosSelected()
    {
        if (!scaleToScreenSize)
            UtilityFunctions.GizmosDrawBounds(area);
        else
        {
            var w = UtilityFunctions.ScreenWidth;
            var h = UtilityFunctions.ScreenHeight;
            var uq = new UnitaryQuadrant(Vector2.zero, w, h);
            Bounds b = new Bounds(uq.GetPoint(area.center), new Vector3(w * area.size.x, h * area.size.y));

            UtilityFunctions.GizmosDrawBounds(b);
        }

        if (isMoving)
            UtilityFunctions.GizmosDrawCross(destination, gizmosColor: Color.red);
    }
}
