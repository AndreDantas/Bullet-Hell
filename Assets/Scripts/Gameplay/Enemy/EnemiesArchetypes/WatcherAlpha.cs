using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class WatcherAlpha : Watcher
{

    public override int Id => 2;
    public override string Name => "Watcher Alpha";
    public GameObject Barrier;

    private void OnEnable()
    {
        Barrier?.Activate();
    }
}
