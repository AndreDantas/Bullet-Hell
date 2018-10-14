using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System;
using System.Linq;
[System.Serializable]
public class GameEffectsObjects
{
    public string name;
    public GameObject effect;

    public GameEffectsObjects(string name, GameObject effect)
    {
        this.name = name;
        this.effect = effect;
    }


}

public class GameEffectsReference : MonoBehaviour
{

    public static GameEffectsReference instance;

    public List<GameEffectsObjects> effects = new List<GameEffectsObjects>();

    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

    }

    public static GameObject DeployEffect(string name, Vector2 position)
    {

        if (instance?.effects == null)
            return null;

        for (int i = 0; i < instance.effects.Count; i++)
        {
            if (instance.effects[i].name.ToLower() == name.ToLower())
            {
                var obj = Instantiate(instance.effects[i].effect);
                obj.transform.position = position;
                return obj;
            }
        }
        return null;
    }

}
