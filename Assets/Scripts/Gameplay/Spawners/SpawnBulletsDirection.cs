using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class SpawnBulletsDirection : SpawnBullets
{
    public SpawnBulletsDirection()
    {
    }

    public SpawnBulletsDirection(BulletSpawnData bulletData) : base(bulletData)
    {
    }
    public override List<Bullet> Spawn()
    {
        return Spawn(bulletData.position);
    }
    public override List<Bullet> Spawn(Vector3 position)
    {
        var bullet = BulletSpawnSystem.SpawnBullet(bulletData);
        if (!bullet)
            return null;

        return new List<Bullet> { bullet };
    }
}
