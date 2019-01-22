using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthUI : HealthUI
{

    public Player player;
    public Vector2 UIScale = Vector2.one;
    public CanvasGroup cg;
    protected Health playerHealth;

    protected override void Awake()
    {
        if (!player)
            player = FindObjectOfType<Player>();
        if (player)
            playerHealth = player.GetComponent<Health>();
        if (playerHealth)
        {
            MaxHealth = playerHealth.MaxHealth;
            UpdateHealth();
        }
        base.Awake();

    }

    public override void InitHealth()
    {
        base.InitHealth();
        if (UIRect)
            UIRect.localScale = UIScale;
    }

    private void Update()
    {
        if (playerHealth)
        {
            if (CurrentHealth != playerHealth.CurrentHealth)
            {
                CurrentHealth = playerHealth.CurrentHealth;
                UpdateHealth();
            }
        }
    }

    protected override void ModifyToken(GameObject token, int order)
    {
        if (order % 2 != 0)
            token.transform.localEulerAngles += new Vector3(0f, 0f, 180);
    }

}
