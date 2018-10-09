using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class Health : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private float currentHealth = 10;
    [SerializeField, HideInInspector]
    private float maxHealth = 10;

    [ShowInInspector]
    public float CurrentHealth { get => currentHealth; set => currentHealth = Mathf.Clamp(value, 0, MaxHealth); }
    [ShowInInspector]
    public float MaxHealth { get => maxHealth; set => maxHealth = UtilityFunctions.ClampMin(value, 0); }

    [ReadOnly]
    public bool isInvincible = false;
    public float invincibleTime;
    [ReadOnly]
    public float elapsedInvincibleTime;
    [ReadOnly]
    public bool wasDamaged = false;
    [ShowInInspector, ReadOnly]
    public bool isDead { get { return currentHealth <= 0; } }

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }
    private void Awake()
    {
        currentHealth = maxHealth;
    }
}
