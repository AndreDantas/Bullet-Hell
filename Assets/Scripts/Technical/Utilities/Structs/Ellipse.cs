using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct Ellipse
{

    [SerializeField, HideInInspector] private Vector2 center;
    [SerializeField, HideInInspector] private float width;
    [SerializeField, HideInInspector] private float height;
    [SerializeField, HideInInspector] private Angle rotation;

    public Ellipse(float height, float width) : this()
    {
        Height = height;
        Width = width;
    }

    public Ellipse(float height, float width, Angle rotation) : this()
    {
        Height = height;
        Width = width;
        Rotation = rotation;
    }

    public Ellipse(float height, float width, Angle rotation, Vector2 center) : this()
    {
        Height = height;
        Width = width;
        Rotation = rotation;
        Center = center;
    }

    [ShowInInspector] public float Height { get => height; set => height = value; }
    [ShowInInspector] public float Width { get => width; set => width = value; }
    [ShowInInspector] public Angle Rotation { get => rotation; set => rotation = value; }
    [ShowInInspector] public Vector2 Center { get => center; set => center = value; }
}
