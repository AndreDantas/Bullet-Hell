using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Unity.Entities;

public class BulletsOutOfTimeSystem : ComponentSystem
{
    struct Data
    {

        public int Length;
        public ComponentArray<Bullet> bullets;
        public ComponentArray<BulletRemoveTime> bulletRemove;
    }

    [Inject] Data data;

    protected override void OnUpdate()
    {
        for (int i = data.Length - 1; i >= 0; i--)
        {
            if (data.bulletRemove[i].elapsedTime >= data.bulletRemove[i].removeTime)
            {
                data.bulletRemove[i].elapsedTime = 0f;
                data.bullets[i].toRemove = true;
            }
            else
            {
                data.bulletRemove[i].elapsedTime += Time.deltaTime;
            }
        }
    }
}
