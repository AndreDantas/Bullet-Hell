using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class SpawnBulletsCircle : SpawnBullets
{

    public float width = 0f;
    public float height = 0f;


    public int amount;

    public SpawnBulletsCircle()
    {
    }

    public SpawnBulletsCircle(int amount, BulletSpawnData data) : base(data)
    {
        this.Amount = amount;
        width = height = 0f;
    }

    public SpawnBulletsCircle(int amount) : base(new BulletSpawnData(Vector2.zero, Vector2.zero, 5f, 1f, BulletsTypes.Circle, Faction.Type.Enemy))
    {
        this.amount = amount;

    }

    [ShowInInspector]
    public int Amount
    {
        get
        {
            return amount;
        }

        set
        {
            value = UtilityFunctions.ClampMin(value, 0);
            amount = value;
        }
    }

    public override List<Bullet> Spawn(Vector3 position)
    {
        List<Bullet> result = new List<Bullet>();
        for (int i = 0; i < amount; i++)
        {

            float angle = (i * Mathf.PI * 2 / amount);
            float newAngleOffSet = bulletData.direction.GetAngle() * Mathf.Deg2Rad;

            angle += newAngleOffSet;

            Vector2 pos = new Vector2(Mathf.Cos(angle) * width, Mathf.Sin(angle) * height) + (Vector2)position;
            var status = BulletSpawnSystem.SpawnBullet(new BulletSpawnData(pos, angle.GetAngleDirection(), bulletData.speed, bulletData.damage, bulletData.type, bulletData.faction));

            result.Add(status);


        }
        return result;
    }

    public override void DrawGizmos(Vector3 position)
    {
        Gizmos.color = Color.red;
        float theta = 0;
        float x = width * Mathf.Cos(theta);
        float y = height * Mathf.Sin(theta);
        Vector3 pos = position + new Vector3(x, y, 0);
        Vector3 newPos = pos;
        Vector3 lastPos = pos;
        for (theta = 0.1f; theta < (Mathf.PI * 2); theta += 0.1f)
        {
            x = width * Mathf.Cos(theta);
            y = height * Mathf.Sin(theta);
            newPos = position + new Vector3(x, y, 0);
            Gizmos.DrawLine(pos, newPos);
            pos = newPos;
        }
        Gizmos.DrawLine(pos, lastPos);
    }


}
