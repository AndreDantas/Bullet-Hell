using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public abstract class SpawnBullets
{
    public BulletSpawnData bulletData;

    public SpawnBullets()
    {
    }

    public SpawnBullets(BulletSpawnData bulletData)
    {
        this.bulletData = new BulletSpawnData(bulletData);
    }

    public virtual List<Bullet> Spawn(Vector3 position)
    {
        return null;
    }
    public virtual List<Bullet> Spawn()
    {
        return Spawn(bulletData.position);
    }

    public virtual void DrawGizmos(Vector3 position)
    {

    }
}
