using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Unity.Entities;

public class BulletsOutOfScreenSystem : ComponentSystem
{
    struct Group
    {
        public int Length;

        public ComponentArray<Bullet> bullets;
        public ComponentArray<BulletOutOfScreenView> outOfView;


    }

    [Inject]
    Group group;
    protected override void OnUpdate()
    {
        for (int i = group.Length - 1; i >= 0; i--)
        {
            if (!group.outOfView[i].bounds.Contains(group.bullets[i].transform.position))
                group.bullets[i].toRemove = true;
        }

    }

}
