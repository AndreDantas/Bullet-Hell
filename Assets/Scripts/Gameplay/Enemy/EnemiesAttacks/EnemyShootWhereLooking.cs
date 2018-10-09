using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class EnemyShootWhereLooking : Enemy
{
    protected SpawnBulletsDirection spawnBullets = new SpawnBulletsDirection();

    protected override void Shoot()
    {

        spawnBullets.bulletData = new BulletSpawnData(shoot.data);
        spawnBullets.bulletData.position = transform.position;
        spawnBullets.bulletData.direction = transform.right;
        spawnBullets.Spawn();

    }

}
