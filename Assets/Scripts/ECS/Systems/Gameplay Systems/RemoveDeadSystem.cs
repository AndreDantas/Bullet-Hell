using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class RemoveDeadSystem : ComponentSystem
{
    private struct Data
    {

        public int Length;
        public ComponentArray<Health> health;
    }

    [Inject] private Data data;

    protected override void OnUpdate()
    {
        var toDeactivate = new List<GameObject>();
        for (int i = data.Length - 1; i >= 0; i--)
        {
            if (data.health[i]?.isDead ?? false)
                if (data.health[i]?.RemoveOnDeath ?? false)
                {
                    toDeactivate.Add(data.health[i].gameObject);

                }
        }

        for (int i = toDeactivate.Count - 1; i >= 0; i--)
        {
            toDeactivate[i].Deactivate();
        }
    }
}
