using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Laser : MonoBehaviour
{
    public float Width = 1f;
    public float Length = 50f;
    public float Angle { get { return transform.eulerAngles.z; } }

    public int damage;

    [AssetsOnly] public GameObject laserBasePrefab;
    [AssetsOnly] public GameObject laserMidPrefab;
    [AssetsOnly] public GameObject laserEndPrefab;

    protected GameObject laserBase, laserMid, laserEnd;

    public virtual void CreateLaser()
    {
        UtilityFunctions.SafeDestroy(laserBase);
        UtilityFunctions.SafeDestroy(laserMid);
        UtilityFunctions.SafeDestroy(laserEnd);

        //Instantiate each part
        //Position each part
        //Stretch middle part
        //Set each part rotation
    }

    public virtual void UpdateLength(float newLength)
    {
        Length = newLength;
        //Change mid part's length
    }

}
