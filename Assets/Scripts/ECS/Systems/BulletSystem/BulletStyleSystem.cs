using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Unity.Entities;

public class BulletStyleSystem : ComponentSystem
{
    struct Group
    {
        public Bullet bullet;
        public BulletStyle style;
        public SpriteRenderer sr;
    }
    protected override void OnUpdate()
    {
        foreach (var item in GetEntities<Group>())
        {
            if (item.style.Sprite != null)
                item.sr.sprite = item.style.Sprite;
            item.sr.color = item.style.Color;
            item.sr.color = new Color(item.sr.color.r, item.sr.color.g, item.sr.color.b, item.style.transparency);
        }
    }
}
