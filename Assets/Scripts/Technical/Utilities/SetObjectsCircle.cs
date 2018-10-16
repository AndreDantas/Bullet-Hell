using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class SetObjectsCircle : MonoBehaviour
{

    public GameObject objectPrefab;
    public int amount = 5;
    public float width = 1f;
    public float height = 1f;
    public float angleOffset;
    public bool scaleToQuantity = false;
    [HideIf("scaleToQuantity")]
    public Vector2 objectsScale = Vector2.one;
    [ShowIf("scaleToQuantity")]
    public Vector2 scaleFactor = Vector2.one;
    [Space(10)]
    public List<GameObject> objects = new List<GameObject>();
    private void OnEnable()
    {
        SetObjects();
    }
    [Button(ButtonSizes.Large)]
    public void SetObjects()
    {
        if (amount <= 0 || objectPrefab == null)
            return;
        objects = new List<GameObject>();
        transform.DestroyChildren(true);
        float x = 0f;
        float y = 0f;
        float angle = 0;
        float angleStep = (360f / amount);

        for (int i = 0; i < (amount); i++)
        {
            y = Mathf.Sin(Mathf.Deg2Rad * angle) * width / 2f;
            x = Mathf.Cos(Mathf.Deg2Rad * angle) * height / 2f;

            var pos = new Vector2(x, y);
            var obj = Instantiate(objectPrefab, transform);
            obj.transform.localScale = scaleToQuantity ? scaleFactor / amount : objectsScale;
            obj.transform.localPosition = pos;
            obj.transform.localEulerAngles = new Vector3(0f, 0f, UtilityFunctions.ClampAngle(angle + angleOffset));

            objects.Add(obj);

            angle += angleStep;
        }

    }

    private void OnDrawGizmosSelected()
    {
        UtilityFunctions.GizmosDrawEllipse(transform.position, width * transform.lossyScale.x, height * transform.lossyScale.x, amount);
    }
}