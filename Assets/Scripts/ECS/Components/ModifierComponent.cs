using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System;
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
            foreach (var item in modifiers)
            {
                if (item.GetType() == m.GetType())
                    return;

            }
            m.Reset();
            modifiers.Add(m);
        }
    }

    public void RemoveModifier(string name)
    {
        for (int i = 0; i < modifiers.Count; i++)
        {
            if (modifiers[i].GetType().Name.Trim().ToLower() == name.Trim().ToLower())
            {
                modifiers.RemoveAt(i);
                return;
            }

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
