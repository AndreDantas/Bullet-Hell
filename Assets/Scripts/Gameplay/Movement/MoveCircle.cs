using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class MoveCircleDetails : MovementDetails
{
    [LabelWidth(200)] public bool scaleToScreenSize;
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
    [LabelWidth(200)] public bool scaleToScreenSize;
    public float rotateSpeed = 5f;
    public Vector2 center;

    public float radius = 1f;


    public override void Move()
    {
        Vector2 center;
        if (scaleToScreenSize)
        {
            var uq = new UnitaryQuadrant(UtilityFunctions.ScreenWidth, UtilityFunctions.ScreenHeight);
            center = uq.GetPoint(this.center);
        }
        else
        {
            center = this.center;
        }

        Angle angle = (((Vector2)transform.position - center).normalized).GetAngle();
        //Debug.Log("Start Angle: " + angle);
        float speed = rotateSpeed * Time.deltaTime;

        Vector3 movePoint = UtilityFunctions.RotatePoint(UtilityFunctions.GetAngleDirection(angle) * radius + center, center, speed * Mathf.Rad2Deg);
        speed = Mathf.Abs(speed);
        //Debug.Log("Transform Pos: " + transform.position + " | Rotate Pos: " + movePoint);

        Vector3 moveDir = (movePoint - transform.position).normalized * speed;
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
            scaleToScreenSize = d.scaleToScreenSize;
        }
    }

    //protected bool OutsideRange()
    //{
    //    var distance = UtilityFunctions.Distance(transform.position, center);
    //    return !Mathf.Approximately(Mathf.Abs(distance), Mathf.Abs(radius));
    //}

    private void OnDrawGizmosSelected()
    {
        Vector2 center;
        if (scaleToScreenSize)
        {
            var uq = new UnitaryQuadrant(UtilityFunctions.ScreenWidth, UtilityFunctions.ScreenHeight);
            center = uq.GetPoint(this.center);
        }
        else
        {
            center = this.center;
        }
        UtilityFunctions.GizmosDrawCircle(center, radius * 2);
        UtilityFunctions.GizmosDrawCross(center, radius / 5f);


    }
}
