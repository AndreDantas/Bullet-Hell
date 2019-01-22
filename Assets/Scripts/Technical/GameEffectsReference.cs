using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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

[System.Serializable]
public struct EffectDetails
{
    public int particlesCount;
    public float particlesSize;
    public Color particlesColor;


    public EffectDetails(int particlesCount, float particlesSize, Color particlesColor)
    {
        this.particlesCount = particlesCount;
        this.particlesSize = particlesSize;
        this.particlesColor = particlesColor;
    }
}

public class GameEffectsReference : MonoBehaviour
{

    public static GameEffectsReference instance;
    public static string DEFAULT_EFFECT
    {
        get
        {
            if (instance)
            {
                return (instance.effects != null && instance.effects.Count > 0) ? instance.effects[0]?.name : "";
            }
            return "";
        }
    }

    public List<GameEffectsObjects> effects = new List<GameEffectsObjects>();

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;


    }

    public static GameObject DeployEffect(string name, Vector2 position, Color? color = null)
    {

        if (instance?.effects == null)
            return null;

        for (int i = 0; i < instance.effects.Count; i++)
        {
            if (instance.effects[i].name.ToLower() == name.ToLower())
            {
                var obj = Instantiate(instance.effects[i].effect);
                obj.transform.position = position;
                ParticleSystem.MainModule settings = obj.GetComponent<ParticleSystem>().main;

                settings.startColor = color ?? Color.white;
                obj.Activate();
                return obj;
            }
        }
        return null;
    }

    public static GameObject DeployEffect(string name, Vector2 position, EffectDetails details)
    {
        if (instance?.effects == null)
            return null;

        for (int i = 0; i < instance.effects.Count; i++)
        {
            if (instance.effects[i].name.ToLower() == name.ToLower())
            {
                var obj = Instantiate(instance.effects[i].effect);
                obj.transform.position = position;

                ParticleSystem.EmissionModule emission = obj.GetComponent<ParticleSystem>().emission;
                ParticleSystem.MainModule settings = obj.GetComponent<ParticleSystem>().main;

                settings.startColor = details.particlesColor;
                emission.burstCount = details.particlesCount;
                settings.startSize = new ParticleSystem.MinMaxCurve(details.particlesSize);
                obj.Activate();
                return obj;
            }
        }
        return null;
    }
}
