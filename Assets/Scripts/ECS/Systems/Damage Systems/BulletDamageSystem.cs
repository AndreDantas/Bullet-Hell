using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
[UpdateAfter(typeof(BulletMovementSystem))]
public class BulletDamageSystem : ComponentSystem
{
    private struct ReceiverData
    {
        public int Length;
        public ComponentArray<Health> Health;
        public ComponentArray<Faction> Faction;
        public ComponentArray<CollisionRadius> Radius;
    }

    [Inject] private ReceiverData receivers;

    private struct BulletData
    {
        public int Length;
        public ComponentArray<Faction> Faction;
        public ComponentArray<BulletDamage> Damage;
        public ComponentArray<Bullet> Bullet;

    }

    [Inject] private BulletData bullets;

    protected override void OnUpdate()
    {
        if (receivers.Length == 0)
            return;

        for (int pi = 0; pi < receivers.Length; ++pi)
        {
            var h = receivers.Health[pi];
            var col = receivers.Radius[pi];
            if (h.wasDamaged)
                h.wasDamaged = false;

            if (h.isInvincible)
                continue;
            int damage = 0;
            var collisionRadius = col.Value;


            Vector2 receiverPos = (Vector2)h.transform.position + receivers.Radius[pi].Offset;
            Faction.Type receiverFaction = receivers.Faction[pi].Value;

            for (int si = 0; si < bullets.Length; ++si)
            {
                if (bullets.Faction[si].Value != receiverFaction && bullets.Bullet[si].gameObject.activeSelf)
                {
                    Vector2 shotPos = bullets.Faction[si].transform.position;

                    Vector2 dir = (shotPos - receiverPos).normalized;

                    if (UtilityFunctions.PointWhitinEllipse(shotPos, receiverPos, collisionRadius.x, collisionRadius.y, col.Angle))
                    {

                        damage = UtilityFunctions.ClampMin(bullets.Damage[si].Value, 1);


                        bullets.Bullet[si].toRemove = true;
                        var effectColor = bullets.Bullet[si].style?.Color;
                        GameEffectsReference.DeployEffect("hit", shotPos, effectColor);

                        //Debug.Log("Bullet pos: " + shotPos);
                        //Debug.Log("Receiver pos: " + receiverPos);
                        //Debug.Log("Distance: " + Vector2.Distance(shotPos, receiverPos));
                        //Debug.Log("Receiver radius: " + collisionRadius);

                        break;
                    }
                }
            }


            if (damage > 0f)
            {
                h.isInvincible = true;
                h.CurrentHealth = Mathf.Max(h.CurrentHealth - damage, 0);
                h.wasDamaged = true;
            }

        }
    }
}
