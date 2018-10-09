using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public static class BulletSpawnSystem
{

    public static event BulletEventHandler OnSpawn;

    public static Bullet SpawnBullet(BulletSpawnData data)
    {
        var bulletObj = BulletPooler.Dequeue(data.type.ToString());
        if (!bulletObj)
            return null;
        var bullet = bulletObj.GetComponent<Bullet>();
        bulletObj.gameObject.transform.position = data.position;

        var move = bullet.movement;

        move.Speed = data.speed;
        move.Direction = data.direction;

        var damage = bullet.damage;

        damage.Value = data.damage;

        OnSpawn?.Invoke(bulletObj);
        bulletObj.Activate();
        return bullet;

    }


}
