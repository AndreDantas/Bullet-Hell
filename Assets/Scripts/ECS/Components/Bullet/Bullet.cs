using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Entities;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public delegate void BulletEventHandler(GameObject bullet);
[System.Serializable]
public struct BulletInfo
{
    public Bullet bullet;



}
public class Bullet : MonoBehaviour
{
    [ReadOnly]
    public bool toRemove = false;
    public float scale = 1f;
    [ReadOnly]
    public BulletMovement movement;
    [ReadOnly]
    public BulletDamage damage;
    [ReadOnly]
    public BulletStyle style;
    private void Awake()
    {
        GetBulletInfo();
    }
    public void GetBulletInfo()
    {
        movement = gameObject.GetComponent<BulletMovement>();
        damage = gameObject.GetComponent<BulletDamage>();
        style = gameObject.GetComponent<BulletStyle>();
    }
    private void OnDisable()
    {
        toRemove = false;
        scale = 1f;
    }


}
