using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class WatcherBeta : Watcher
{
    public override int Id => 3;
    public override string Name => "Watcher Beta";
    public Timer objectsOrbitingTimer = new Timer(0.2f, true);
    public SetObjectsCircle ObjectsOrbiting;
    public GameObject partPrefab;

    protected override void Awake()
    {
        base.Awake();
        if (!ObjectsOrbiting)
            ObjectsOrbiting = GetComponentInChildren<SetObjectsCircle>();
    }

    public override void RequestShoot()
    {
        base.RequestShoot();

        if (ObjectsOrbiting)
        {
            if (objectsOrbitingTimer.isFinished)
            {
                objectsOrbitingTimer.Reset();
                var spawnBullets = new SpawnBulletsDirection(shoot.data);
                spawnBullets.bulletData.type = BulletsTypes.Diamond;
                var list = ObjectsOrbiting.objects;
                for (int i = 0; i < list.Count; i++)
                {
                    if (!list[i].activeSelf)
                        continue;
                    var dir = list[i].transform.right;
                    spawnBullets.bulletData.direction = dir;
                    spawnBullets.bulletData.position = list[i].transform.position;

                    spawnBullets.Spawn();
                }
            }
            else
                objectsOrbitingTimer.Update();
        }
    }
}
