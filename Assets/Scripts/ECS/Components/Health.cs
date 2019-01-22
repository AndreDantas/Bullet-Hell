using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private int currentHealth = 10;
    [SerializeField, HideInInspector]
    private int maxHealth = 10;

    [ShowInInspector]
    public int CurrentHealth { get => currentHealth; set => currentHealth = Mathf.Clamp(value, 0, MaxHealth); }
    [ShowInInspector]
    public int MaxHealth { get => maxHealth; set => maxHealth = UtilityFunctions.ClampMin(value, 0); }

    [ReadOnly]
    public bool isInvincible = false;
    public float invincibleTime;
    [ReadOnly]
    public float elapsedInvincibleTime;
    [ReadOnly]
    public bool wasDamaged = false;

    [ShowInInspector, ReadOnly]
    public bool isDead { get => currentHealth <= 0; }

    public bool RemoveOnDeath = true;

    private void OnDisable()
    {
        wasDamaged = false;
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;

    }
    private void Awake()
    {
        currentHealth = maxHealth;
    }
}
