﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Unity.Entities;
public class PlayerShootSystem : ComponentSystem
{

    struct Data
    {
        public int Length;
        public ComponentArray<Player> player;
        public ComponentArray<ShootBullets> shoot;
    }

    [Inject] Data data;

    protected override void OnUpdate()
    {
        bool firing = false;

        for (int i = data.Length - 1; i >= 0; i--)
        {
            var shoot = data.shoot[i];
            shoot.shootTimer.Update();
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
                firing = data.player[i].moving;
            else
                firing = Input.GetButton("Fire");

            if (firing)
            {
                if (shoot.shootTimer.isFinished)
                {

                    var spawn = new SpawnBulletsDirection();
                    var data = shoot.data;
                    data.position = shoot.transform.position;
                    spawn.bulletData = data;
                    var bullet = spawn.Spawn();
                    if (bullet != null ? bullet.Count > 0 : false)
                    {
                        bullet[0].GetComponent<Bullet>().scale = 1.5f;
                    }
                    shoot.shootTimer.Reset();
                }

            }
        }
    }
}
