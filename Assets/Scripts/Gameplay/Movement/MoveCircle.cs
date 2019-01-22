using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class MoveCircleDetails : MovementDetails
{
    public float rotateSpeed = 5f;
    public float radius = 1f;
    public Vector2 center;

    public override void AddMovementComponent(GameObject obj)
    {
        obj.gameObject.AddComponent<MoveCircle>().SetMovement(this);
    }
}

public class MoveCircle : Movement
{
    public float rotateSpeed = 5f;
    public Vector2 center;

    public float radius = 1f;


    public override void Move()
    {
        Angle angle = (((Vector2)transform.position - center).normalized).GetAngle();
        //Debug.Log("Start Angle: " + angle);
        float speed = rotateSpeed * Time.deltaTime;
        float rotate = angle * Mathf.Deg2Rad + Time.deltaTime * rotateSpeed;
        //Debug.Log("Rotated Angle: " + rotate * Mathf.Rad2Deg);
        Vector3 movePoint = UtilityFunctions.RotatePoint(transform.position, center, rotate * Mathf.Rad2Deg - angle);
        //Debug.Log("Transform Pos: " + transform.position + " | Rotate Pos: " + movePoint);
        Vector3 rangeAdjust = Vector3.zero;
        if (OutsideRange())
        {
            Vector3 correctionShortestPoint = UtilityFunctions.ShortestPointInCircle(transform.position, center, radius);
            //Debug.Log("Correction Point: " + correctionShortestPoint);
            rangeAdjust = (correctionShortestPoint - transform.position);

            if (UtilityFunctions.Distance(transform.position, transform.position + rangeAdjust.normalized * speed) <
                UtilityFunctions.Distance(transform.position, correctionShortestPoint))
            {
                rangeAdjust = rangeAdjust.normalized * speed;
            }
        }

        Vector3 moveDir = (movePoint - transform.position).normalized * speed + rangeAdjust;
        //Debug.Log("Move Direction: " + moveDir);
        transform.position += moveDir;
    }

    public override void SetMovement(MovementDetails details)
    {
        if (details is MoveCircleDetails)
        {
            MoveCircleDetails d = (MoveCircleDetails)details;
            rotateSpeed = d.rotateSpeed;
            center = d.center;
            radius = d.radius;
        }
    }

    protected bool OutsideRange()
    {
        var distance = UtilityFunctions.Distance(transform.position, center);
        return !Mathf.Approximately(Mathf.Abs(distance), Mathf.Abs(radius));
    }

    private void OnDrawGizmosSelected()
    {
        UtilityFunctions.GizmosDrawCircle(center, radius * 2);
        UtilityFunctions.GizmosDrawCross(center, radius / 5f);


    }
}
