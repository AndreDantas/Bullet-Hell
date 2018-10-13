using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class Shoot : MonoBehaviour
{
    public Timer shootTimer = new Timer(0.5f, true);

    [Header("Bullet Info")]
    public BulletSpawnData data;

    private void OnDisable()
    {
        shootTimer.Finish();
    }
}
