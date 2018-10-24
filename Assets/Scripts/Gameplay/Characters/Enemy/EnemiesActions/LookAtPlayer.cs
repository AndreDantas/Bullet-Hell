using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class LookAtPlayer : MonoBehaviour
{

    public float angleOffset;
    Player player;

    private void Update()
    {
        if (player)
        {
            Vector2 dir = player.transform.position - transform.position;
            dir.Normalize();

            transform.eulerAngles = new Vector3(0f, 0f, dir.GetAngle() + angleOffset);
        }
    }

    private void OnEnable()
    {
        player = FindObjectOfType<Player>();
    }
}
