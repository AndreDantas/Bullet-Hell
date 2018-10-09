using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class Shoot : MonoBehaviour
{
    [ReadOnly]
    public bool CanShoot = true;
    public float Cooldown = 1f;
    [ReadOnly]
    public float elapsedCooldownTime;

    [Header("Bullet Info")]
    public BulletSpawnData data;

    private void OnDisable()
    {
        elapsedCooldownTime = 0f;
    }
}
