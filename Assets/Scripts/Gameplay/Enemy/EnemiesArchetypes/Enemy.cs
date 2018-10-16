using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Unity.Entities;
public abstract class Enemy : MonoBehaviour
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
