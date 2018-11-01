using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HealthToken : MonoBehaviour
{

    public bool damaged;

    [ButtonGroup("1"), Button(ButtonSizes.Large)]
    public virtual void DamageAnim()
    {
        damaged = true;
    }
    [ButtonGroup("1"), Button(ButtonSizes.Large)]
    public virtual void HealAnim()
    {
        damaged = false;
    }
}
