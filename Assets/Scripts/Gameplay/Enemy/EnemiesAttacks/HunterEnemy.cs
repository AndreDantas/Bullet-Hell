using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class HunterEnemy : Enemy
{

    protected SpawnBulletsTarget spawnBullets = new SpawnBulletsTarget();

    protected override void OnEnable()
    {

        spawnBullets = new SpawnBulletsTarget(player.gameObject);
    }

    protected override void Shoot()
    {
        spawnBullets.bulletData = new BulletSpawnData(shoot.data);
        spawnBullets.bulletData.position = transform.position;
        foreach (var item in spawnBullets.Spawn())
        {
            var m = item.gameObject.GetComponent<ModifierComponent>();
            if (!m)
                return;
            var fm = new BulletFollowModifier();
            fm.bulletTarget = item;
            fm.followTarget = player.transform;
            fm.rotateSpeed = 220;
            m.AddModifier(fm);
        }

    }
}
