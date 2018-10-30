using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{

    public RectTransform UIRect;

    [AssetsOnly] public GameObject HealthToken;
    [AssetsOnly] public GameObject HealthTokenDamaged;
    public float tokenDistance = 15;
    public bool Resize;
    [ShowIf("Resize")]
    public Vector2 NewSize = new Vector2(100f, 100f);
    public int HealthTotal;

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
            if (currentHealth != value)
            {
                currentHealth = Mathf.Clamp(value, 0, HealthTotal);
                UpdateHealth();
            }
        }
    }

    protected List<GameObject> healthTokens = new List<GameObject>();

    protected virtual void Awake()
    {
        if (!UIRect)
            UIRect = GetComponent<RectTransform>();
        CurrentHealth = HealthTotal;
        UpdateHealth();
    }
    [Button("Update", ButtonSizes.Large)]
    public virtual void UpdateHealth()
    {
        if (!HealthToken || !UIRect)
            return;

        for (int i = healthTokens.Count - 1; i >= 0; i--)
        {
            UtilityFunctions.SafeDestroy(healthTokens[i]);
        }
        UIRect.DestroyChildren(true);
        healthTokens = new List<GameObject>();
        Vector2 Size;
        if (!Resize)
            Size = HealthToken.GetComponent<RectTransform>().sizeDelta;
        else
        {
            Size = NewSize;
        }

        for (int i = 0; i < HealthTotal; i++)
        {
            GameObject healthObj;
            if (currentHealth > i)
            {
                healthObj = Instantiate(HealthToken, UIRect);
            }
            else
            {
                if (!HealthTokenDamaged)
                    break;
                healthObj = Instantiate(HealthTokenDamaged, UIRect);
            }

            var rect = healthObj.GetComponent<RectTransform>();
            rect.localScale = Vector3.one;
            rect.anchoredPosition = new Vector2(i * Size.x + Size.x / 2f + (i > 0 ? tokenDistance * i : 0f), 0f);
            rect.anchorMax = new Vector2(0, 0.5f);
            rect.anchorMin = new Vector2(0, 0.5f);

            if (Resize)
                rect.sizeDelta = NewSize;

            ModifyHealthToken(healthObj, i);
            healthTokens.Add(healthObj);
        }
    }

    protected virtual void ModifyHealthToken(GameObject healthToken, int tokenOrder)
    {

    }

    private void Reset()
    {
        if (!UIRect)
            UIRect = GetComponent<RectTransform>();
    }
}
