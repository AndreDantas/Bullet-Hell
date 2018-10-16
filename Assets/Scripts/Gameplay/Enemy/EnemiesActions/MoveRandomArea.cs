using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class MoveRandomArea : Movement
{
    public Bounds area;
    public Timer waitTime = new Timer(0.5f, true);
    public EasingEquationsType moveEquation = EasingEquationsType.EaseInOutCubic;
    protected Vector2 destination;


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

                destination = area.RandomPoint();

                isMoving = true;
                var t = transform.MoveTo(destination, moveTime, EasingEquations.GetEquation(moveEquation));
                t.destroyOnDisable = true;
                t.easingControl.completedEvent += (object sender, System.EventArgs args) => isMoving = false;
                waitTime.Reset();
            }
        }

    }

    private void OnDisable()
    {
        isMoving = false;
    }

    private void OnDrawGizmosSelected()
    {
        UtilityFunctions.GizmosDrawBounds(area);
        if (isMoving)
            UtilityFunctions.GizmosDrawCross(destination, gizmosColor: Color.red);
    }
}
