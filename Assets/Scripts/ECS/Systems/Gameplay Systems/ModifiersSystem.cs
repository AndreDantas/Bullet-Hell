using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Unity.Entities;
public class ModifiersSystem : ComponentSystem
{

    struct Data
    {


        public ModifierComponent modifier;
    }

    //[Inject] Data data;

    protected override void OnUpdate()
    {

        foreach (var item in GetEntities<Data>())
        {
            var modifiers = item.modifier.GetModifiers();
            for (int j = 0; j < modifiers.Count; j++)
            {
                modifiers[j].Execute();
            }
        }
    }
}
