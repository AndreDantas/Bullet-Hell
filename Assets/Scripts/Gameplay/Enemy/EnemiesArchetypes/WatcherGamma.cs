using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class WatcherGamma : Watcher
{
    public override int Id => 4;
    public override string Name => "Watcher Gamma";
    public SetObjectsCircle ObjectsOrbiting;
    public Timer objectsOrbitingTimer = new Timer(0.2f, true);
    public GameObject partPrefab;
    public GameObject Barrier;
    protected override void Awake()
    {
        base.Awake();
        if (!ObjectsOrbiting)
            ObjectsOrbiting = GetComponentInChildren<SetObjectsCircle>();
    }
    protected override void OnEnable()
    {
        Barrier?.Activate();
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
