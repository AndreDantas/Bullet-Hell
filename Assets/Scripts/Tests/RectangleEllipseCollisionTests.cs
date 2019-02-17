using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RectangleEllipseCollisionTests : MonoBehaviour
{

    public Rectangle R = new Rectangle(1f, 2f);
    public Ellipse E = new Ellipse(2f, 2f, 0f, Vector2.up);

    [ShowInInspector] public bool Collision1 { get { return UtilityFunctions.EllipseIntersectsRectangle(E, R); } }
    [ShowInInspector] public float D { get { return Vector2.Distance(R.Center, E.Center); } }


    private void OnDrawGizmosSelected()
    {
        UtilityFunctions.GizmosDrawRectangle(R, Color.red);
        UtilityFunctions.GizmosDrawEllipse(E, gizmosColor: Color.red);

        List<Vector2> l = new List<Vector2> { R.TopLeft, R.TopRight, R.BottomRight, R.BottomLeft };

        Vector2 offset = new Vector2(3, 0f);
        Vector2 RectNewCenter = UtilityFunctions.RotatePoint(R.Center - E.Center, Vector2.zero, -E.Rotation);
        for (int i = 0; i < l.Count; i++)
        {
            l[i] -= E.Center;
            l[i] = UtilityFunctions.RotatePoint(l[i], Vector2.zero, -E.Rotation);
            l[i] = new Vector2(l[i].x * (1f / E.Width),
                               (l[i].y) * (1f / E.Height));
            l[i] = UtilityFunctions.RotatePoint(l[i], Vector2.zero, E.Rotation);
            l[i] += offset;
            l[i] += E.Center;
        }
        UtilityFunctions.GizmosDrawCircle(E.Center + offset, 1f);
        UtilityFunctions.GizmosDrawQuadrilateral(l[0], l[1], l[2], l[3]);
    }
}
