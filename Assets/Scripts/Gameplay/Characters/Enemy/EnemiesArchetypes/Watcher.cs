using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Watcher : CoreEnemy
{
    public override int Id => 1;
    [SerializeField]
    protected ShootBullets shoot;
    public override string Name => "Watcher";

    public GameObject Eye;

    protected override void Awake()
    {
        base.Awake();

    }
    public override void Init()
    {
        base.Init();
        if (!shoot)
            shoot = GetComponent<ShootBullets>();
    }
    public override void RequestShoot()
    {
        base.RequestShoot();
        if (shoot?.shootTimer.isFinished ?? false)
        {

            Shoot();
            shoot.shootTimer.Reset();
        }
    }
    protected override void Shoot()
    {
        if (player && player.gameObject.activeInHierarchy)
        {
            var dir = player.transform.position - transform.position;
            dir.Normalize();

            SpawnBulletsDirection spawnBullets = new SpawnBulletsDirection();
            spawnBullets.bulletData = shoot.data;
            spawnBullets.bulletData.position = transform.position;
            spawnBullets.bulletData.direction = dir;
            spawnBullets.Spawn();
        }
    }
}

