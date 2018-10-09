using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class SpawnBulletsTarget : SpawnBullets
{
    public GameObject target;

    public SpawnBulletsTarget()
    {
    }

    public SpawnBulletsTarget(GameObject target)
    {
        this.target = target;
    }

    public SpawnBulletsTarget(BulletSpawnData bulletData) : base(bulletData)
    {
    }

    public override List<Bullet> Spawn(Vector3 position)
    {
        var data = new BulletSpawnData(bulletData);
        data.position = position;

        var direction = target != null ? (Vector2)(target.transform.position - position) : bulletData.direction;
        data.direction = direction.normalized;

        var bullet = BulletSpawnSystem.SpawnBullet(data);

        return new List<Bullet> { bullet };
    }


}
