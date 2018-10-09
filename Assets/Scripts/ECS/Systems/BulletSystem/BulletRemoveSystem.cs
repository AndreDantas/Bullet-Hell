using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Unity.Entities;

public class BulletRemoveSystem : ComponentSystem
{
    struct Data
    {
        public int Length;
        public ComponentArray<Bullet> bullets;
    }

    [Inject] Data data;

    public static event BulletEventHandler OnRemove;
    protected override void OnUpdate()
    {
        for (int i = data.Length - 1; i >= 0; i--)
        {
            if (data.bullets[i].toRemove)
            {
                data.bullets[i].toRemove = false;
                BulletPooler.Enqueue(data.bullets[i].transform.gameObject);
                OnRemove?.Invoke(data.bullets[i].transform.gameObject);
            }
        }
    }
}
