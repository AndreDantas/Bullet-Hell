using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System;
public abstract class CoreEnemy : Enemy
{
    [ShowInInspector, ReadOnly, PropertyOrder(-2)]
    public abstract int Id { get; }
    [ShowInInspector, ReadOnly, PropertyOrder(-1)]
    public abstract string Name { get; }

    private void TestRespawn()
    {
        gameObject.Activate();
    }
    private void OnDisable()
    {
        Invoke("TestRespawn", 5f);
    }

}
