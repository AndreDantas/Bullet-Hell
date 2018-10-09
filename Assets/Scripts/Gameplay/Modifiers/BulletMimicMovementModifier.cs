using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
[System.Serializable]
public class BulletMimicMovementModifier : BulletMimicModifier
{
    public override void Execute()
    {
        if (bulletTarget == null || bulletMimic == null)
            return;
        bulletTarget.movement?.SetValues(bulletMimic.movement);
    }

    public override void Reset()
    {

    }
}
