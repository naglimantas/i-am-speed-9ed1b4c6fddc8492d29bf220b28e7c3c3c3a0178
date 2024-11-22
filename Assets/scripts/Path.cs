using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> points = new();

    public Transform GetNextPoint(Transform point)
    {
        int index = points.IndexOf(point);
        index++;
        if (index == points.Count) index = 0;
        return points[index];

    }

    public Transform GetClosestPoint(Vector3 position)
    {
        float minDistance = float.MaxValue;
        Transform closestPoint = points[0];
        foreach (Transform p in points)
        {
            float d = Vector3.Distance(p.position, position);
            if (d < minDistance)
            {
                minDistance = d;
                closestPoint = p;
            }
        }
        return closestPoint;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for (int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.DrawLine(points[i].position, points[i + 1].position);
        }

        Gizmos.DrawLine(points[^1].position, points[0].position);
    }
}