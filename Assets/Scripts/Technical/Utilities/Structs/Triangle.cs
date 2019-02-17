using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct Triangle
{
    [SerializeField, HideInInspector] private Vector2 v3;
    [SerializeField, HideInInspector] private Vector2 v1;
    [SerializeField, HideInInspector] private Vector2 v2;

    [ShowInInspector] public Vector2 V1 { get => v1; set => v1 = value; }
    [ShowInInspector] public Vector2 V2 { get => v2; set => v2 = value; }
    [ShowInInspector] public Vector2 V3 { get => v3; set => v3 = value; }

    public Triangle(Vector2 v1) : this()
    {
        V1 = v1;
    }

    public Triangle(Vector2 v1, Vector2 v2) : this()
    {
        V1 = v1;
        V2 = v2;
    }

    public Triangle(Vector2 v1, Vector2 v2, Vector2 v3) : this()
    {
        V1 = v1;
        V2 = v2;
        V3 = v3;
    }
}
