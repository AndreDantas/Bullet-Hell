using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Unity.Entities;
public class DamageShakeEffectSystem : ComponentSystem
{

    struct Data
    {
        public int Length;
        public ComponentArray<Health> Health;
        public ComponentArray<DamageShakeEffect> DamageEfct;
    }

    [Inject] Data data;

    protected override void OnUpdate()
    {

        for (int i = data.Length - 1; i >= 0; i--)
        {

            var health = data.Health[i];
            var dmgEf = data.DamageEfct[i];
            if (health.wasDamaged)
            {
                dmgEf.StartEffect();

            }
            if (dmgEf.inProgress)
            {
                dmgEf.UpdateEffect();
            }

        }
    }
}
