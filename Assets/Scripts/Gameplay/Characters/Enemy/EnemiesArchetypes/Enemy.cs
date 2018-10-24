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
    [SerializeField]
    protected Shoot shoot;
    protected Player player;
    protected virtual void Awake()
    {
        if (!shoot)
            shoot = GetComponent<Shoot>();
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
        if (shoot?.shootTimer.isFinished ?? false)
        {

            Shoot();
            shoot.shootTimer.Reset();
        }
    }

    protected abstract void Shoot();
    protected virtual void OnEnable()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void Reset()
    {
        shoot = GetComponent<Shoot>();
        movement = GetComponent<Movement>();
    }
}
