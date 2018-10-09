using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
[System.Serializable]
public class BulletFollowModifier : BulletModifier
{

    public Transform followTarget;
    public float rotateSpeed = 2f;
    public float followFor = 5f;
    protected float followTime = 0f;

    public BulletFollowModifier(Transform followTarget, float rotateSpeed)
    {
        this.followTarget = followTarget;
        this.rotateSpeed = rotateSpeed;
        followTime = 0f;

    }

    public BulletFollowModifier()
    {
        followTime = 0f;
    }

    public BulletFollowModifier(Transform followTarget, float rotateSpeed, float followFor) : this(followTarget, rotateSpeed)
    {
        this.followFor = followFor;
    }

    public override void Execute()
    {
        if (bulletTarget == null || followTarget == null)
            return;
        if (followFor > 0)
        {
            if (followTime >= followFor)
                return;
            followTime += Time.deltaTime;
        }
        Vector2 direction = followTarget.position - bulletTarget.transform.position;
        direction.Normalize();

        var bulletAngle = bulletTarget.movement.Direction.GetAngle();
        var targetAngle = direction.GetAngle();
        var difference = UtilityFunctions.SmallerAngleDifference(direction.GetAngle(), bulletAngle);

        float rotateAmount = bulletAngle;
        rotateAmount = rotateSpeed * Time.deltaTime;
        if (Mathf.Abs(UtilityFunctions.ClampAngle(bulletAngle + difference - targetAngle + 0.1f)) <=
                    Mathf.Abs(UtilityFunctions.ClampAngle(bulletAngle - difference - targetAngle + 0.1f)))
        {

            bulletTarget.movement.Direction = Quaternion.Euler(0, 0, rotateAmount) * bulletTarget.movement.Direction;
        }
        else
        {

            bulletTarget.movement.Direction = Quaternion.Euler(0, 0, -rotateAmount) * bulletTarget.movement.Direction;
        }




    }

    public override void Reset()
    {
        followTime = 0f;
    }
}
