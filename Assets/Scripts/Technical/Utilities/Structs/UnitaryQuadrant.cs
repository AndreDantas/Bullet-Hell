using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;
[System.Serializable]
public struct UnitaryQuadrant
{

    public Vector2 center;
    [SerializeField, HideInInspector]
    private float width;
    [ShowInInspector]
    public float Width { get => width; set => width = UtilityFunctions.ClampMin(value, 0f); }
    [SerializeField, HideInInspector]
    private float height;
    [ShowInInspector]
    public float Height { get => height; set => height = UtilityFunctions.ClampMin(value, 0f); }

    public UnitaryQuadrant(Vector2 center, float width, float height) : this()
    {
        this.center = center;
        Width = width;
        Height = height;
    }

    public UnitaryQuadrant(float width, float height) : this()
    {
        center = Vector2.zero;
        Width = width;
        Height = height;
    }




    /// <summary>
    /// Usage ex: refPoint = (0,0) -> returns the center; refPoint = (1,1) -> returns top right;
    /// </summary>
    /// <param name="refPoint"></param>
    /// <returns></returns>
    public Vector2 GetPoint(Vector2 refPoint)
    {
        return new Vector2(GetXCoord(refPoint.x), GetYCoord(refPoint.y)) + center;
    }

    public float GetXCoord(float refX)
    {
        return refX * width / 2f;
    }
    public float GetYCoord(float refY)
    {
        return refY * height / 2f;
    }

    public Vector2 TopRight { get { return GetPoint(new Vector2(1, 1)); } }
    public Vector2 TopLeft { get { return GetPoint(new Vector2(-1, 1)); } }
    public Vector2 BottomRight { get { return GetPoint(new Vector2(1, -1)); } }
    public Vector2 BottomLeft { get { return GetPoint(new Vector2(-1, -1)); } }
}
