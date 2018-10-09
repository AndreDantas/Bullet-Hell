using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class BulletSpawnTests : MonoBehaviour
{
    public Color color = Color.red;
    public int CircleSpawnAmount = 5;
    public float speed = 1f;
    [Button(ButtonSizes.Large)]
    [DisableInEditorMode]
    public void TestCircleSpawn()
    {
        var s = new SpawnBulletsCircle(CircleSpawnAmount);
        s.bulletData.direction = rotate.GetAngleDirection();
        s.bulletData.speed = speed;
        s.bulletData.type = BulletsTypes.Diamond;
        foreach (var item in s.Spawn(Vector3.zero))
        {
            item.GetComponent<BulletStyle>().Color = color;
        }

    }
    [SerializeField]
    float rotSpeed = 10f;
    float rotate = 1f;

    private void Start()
    {
        InvokeRepeating("TestCircleSpawn", 0f, 0.1f);
    }

    private void Update()
    {
        rotate += Time.deltaTime * rotSpeed;
        rotate = UtilityFunctions.ClampAngle(rotate);
        color = Colors.RandomColor();
    }
}
