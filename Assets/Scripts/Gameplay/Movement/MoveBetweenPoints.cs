using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
[System.Serializable]
public class MoveBetweenPoints : Movement
{
    public enum MoveType { Cycle, PingPong }

    public MoveType type = MoveType.Cycle;
    protected bool reversing;
    public EasingEquationsType moveEquation = EasingEquationsType.EaseInOutCubic;
    public Timer waitTime = new Timer(0.5f, true);

    public List<Vector2> path = new List<Vector2>();
    protected int index = -1;


    public override void Move()
    {
        if (path?.Count == 0 || !active)
            return;

        if (!isMoving)
        {

            if (!waitTime.isFinished)
            {
                waitTime.Update();
            }
            else
            {
                if (reversing)
                    index--;
                else
                    index++;

                if (index == 0 && reversing && type == MoveType.PingPong)
                    reversing = false;
                else if (index == path.Count - 1 && type == MoveType.PingPong)
                    reversing = true;

                if (!path.ValidIndex(index))
                {
                    index = 0;
                }

                isMoving = true;
                var destination = path[index];


                var t = transform.MoveTo(destination, moveTime, EasingEquations.GetEquation(moveEquation));
                t.destroyOnDisable = true;
                t.easingControl.completedEvent += (object sender, System.EventArgs args) => isMoving = false;
                waitTime.Reset();
            }
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        index = -1;
        reversing = false;
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < path?.Count; i++)
        {
            var point = path[i];

            UtilityFunctions.GizmosDrawCross(point, gizmosColor: Color.red);
        }
    }
}
