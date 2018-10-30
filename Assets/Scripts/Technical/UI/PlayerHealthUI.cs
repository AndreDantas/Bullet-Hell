using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthUI : HealthUI
{
    public Player player;
    protected Health playerHealth;

    protected override void Awake()
    {
        if (!player)
            player = FindObjectOfType<Player>();
        if (player)
            playerHealth = player.GetComponent<Health>();
        if (playerHealth)
        {
            HealthTotal = playerHealth.MaxHealth;
            UpdateHealth();
        }
        base.Awake();

    }

    private void Update()
    {
        if (playerHealth)
        {
            if (playerHealth.wasDamaged)
            {
                CurrentHealth = playerHealth.CurrentHealth;
                UpdateHealth();
            }
        }
    }

    protected override void ModifyHealthToken(GameObject healthToken, int tokenOrder)
    {
        if (tokenOrder % 2 != 0)
            healthToken.transform.localEulerAngles += new Vector3(0f, 0f, 180);
    }
}
