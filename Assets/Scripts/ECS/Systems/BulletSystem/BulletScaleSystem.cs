using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Unity.Entities;
public class BulletScaleSystem : ComponentSystem
{

    struct Data
    {

        public int Length;
        public ComponentArray<Bullet> bullets;
    }

    [Inject] Data data;

    protected override void OnUpdate()
    {

        for (int i = data.Length - 1; i >= 0; i--)
        {
            var scale = data.bullets[i].scale;
            data.bullets[i].transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
