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
    public GameObject ObjectsOrbiting;
    public GameObject partPrefab;
    public GameObject Barrier;

    protected override void OnEnable()
    {
        Barrier?.Activate();
    }
}
