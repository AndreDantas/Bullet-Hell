using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
    public RectTransform UIRect;
    public GameObject healthTokenPrefab;
    public float tokenDistance = 15;

    [SerializeField, HideInInspector]
    protected List<HealthToken> healthTokens = new List<HealthToken>();

    [SerializeField, HideInInspector] private int currentHealth;

    [ShowInInspector]
    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = Mathf.Clamp(value, 0, MaxHealth);
        }
    }

    [SerializeField, HideInInspector] private int maxHealth;

    [ShowInInspector]
    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }

        set
        {
            maxHealth = UtilityFunctions.ClampMin(value, 0);
        }
    }

    protected virtual void Awake()
    {
        if (!UIRect)
            UIRect = GetComponent<RectTransform>();
        CurrentHealth = MaxHealth;
        InitHealth();
        UpdateHealth();
    }

    [Button(ButtonSizes.Large)]
    public virtual void InitHealth()
    {
        if (!healthTokenPrefab || !UIRect)
            return;
        if (!healthTokenPrefab.CheckForComponent<HealthToken>())
            return;

        for (int i = healthTokens.Count - 1; i >= 0; i--)
        {
            UtilityFunctions.SafeDestroy(healthTokens[i]?.gameObject);
        }

        healthTokens = new List<HealthToken>();

        var Size = healthTokenPrefab.GetComponent<RectTransform>().sizeDelta;

        for (int i = 0; i < MaxHealth; i++)
        {
            var healthObj = Instantiate(healthTokenPrefab, UIRect);
            var rect = healthObj.GetComponent<RectTransform>();

            rect.localScale = Vector3.one;
            rect.anchoredPosition = new Vector2(i * Size.x + Size.x / 2f + (i > 0 ? tokenDistance * i : 0f), 0f);
            rect.anchorMax = new Vector2(0, 0.5f);
            rect.anchorMin = new Vector2(0, 0.5f);
            ModifyToken(healthObj, i);
            healthTokens.Add(healthObj.GetComponent<HealthToken>());

        }
    }

    protected virtual void ModifyToken(GameObject token, int order)
    {

    }

    public virtual void UpdateHealth()
    {
        if (!healthTokenPrefab || !UIRect)
            return;

        for (int i = 0; i < healthTokens.Count; i++)
        {
            var token = healthTokens[i];
            if (CurrentHealth < i + 1)
            {
                if (!token.damaged)
                    token.DamageAnim();
            }
            else
            {
                if (token.damaged)
                    token.HealAnim();
            }
        }
    }

    private void Reset()
    {
        if (!UIRect)
            UIRect = GetComponent<RectTransform>();
    }
}
