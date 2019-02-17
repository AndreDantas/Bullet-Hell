using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;
public abstract class Enemy : Character
{
    public bool active = true;
    public Movement movement;

    protected Player player;
    protected virtual void Awake()
    {
        Init();
    }

    public virtual void Init()
    {

        if (!movement)
            movement = GetComponent<Movement>();
    }

    protected virtual void Update()
    {
        if (!active)
            return;
        RequestShoot();
        movement?.Move();

    }

    public virtual void RequestShoot()
    {
        if (!active)
            return;

    }

    protected abstract void Shoot();
    protected virtual void OnEnable()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void Reset()
    {
        movement = GetComponent<Movement>();
    }
}
