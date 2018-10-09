using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Unity.Entities;
public class ModifierComponent : MonoBehaviour
{
    [ShowInInspector]
    public List<string> CurrentModifiers
    {
        get
        {

            var strings = new List<string>();
            foreach (var item in modifiers)
            {
                strings.Add(item.GetType().Name);
            }
            return strings;
        }
    }
    protected List<Modifier> modifiers = new List<Modifier>();

    public void AddModifier(Modifier m)
    {
        if (m != null)
        {
            m.Reset();
            modifiers.Add(m);
        }
    }

    public List<Modifier> GetModifiers()
    {
        return modifiers;
    }

    private void OnDisable()
    {
        modifiers.Clear();
    }
}
