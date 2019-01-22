using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Unity.Entities;
public class InvincibilitySystem : ComponentSystem
{

    struct Data
    {
        public int Length;
        public ComponentArray<Health> Health;
    }

    [Inject] Data data;

    protected override void OnUpdate()
    {
        for (int i = 0; i < data.Length; i++)
        {
            var health = data.Health[i];

            if (!health.isInvincible)
                continue;

            health.elapsedInvincibleTime += Time.deltaTime;

            if (health.elapsedInvincibleTime >= health.invincibleTime)
            {
                health.isInvincible = false;
                health.elapsedInvincibleTime = 0f;
            }

        }
    }

}
