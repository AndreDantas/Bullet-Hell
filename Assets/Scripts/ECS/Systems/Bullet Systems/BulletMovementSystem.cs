using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
[UpdateBefore(typeof(RotateObjectSystem))]
public class BulletMovementSystem : ComponentSystem
{
    private struct BulletGroup
    {
        public Bullet bullet;
        public Transform transform;
        public BulletMovement movement;

    }

    protected override void OnUpdate()
    {
        var deltaTime = Time.deltaTime;
        foreach (var entity in GetEntities<BulletGroup>())
        {
            Vector2 dir = entity.movement.Direction.normalized;

            var position = (Vector2)entity.transform.position;

            position += entity.movement.Speed * dir * deltaTime;

            entity.transform.position = position;
            if (entity.movement.changeTransformOrientation)
                entity.transform.eulerAngles = new Vector3(entity.transform.eulerAngles.x, entity.transform.eulerAngles.y, dir.GetAngle() - entity.movement.AngleOffset);

        }
    }
}
