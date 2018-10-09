using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Unity.Entities;
public class RemoveDeadSystem : ComponentSystem
{

    struct Data
    {

        public int Length;
        public ComponentArray<Health> health;
    }

    [Inject] Data data;

    protected override void OnUpdate()
    {
        var toDeactivate = new List<GameObject>();
        for (int i = data.Length - 1; i >= 0; i--)
        {
            if (data.health[i]?.isDead ?? false)
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
