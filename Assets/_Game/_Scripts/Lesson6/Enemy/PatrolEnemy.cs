using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : EnemyBase
{
    [SerializeField] List<Transform> points;
    int currentPoint;
    void Start()
    {
        SetValue(2, 10,1, 2);
    }
    void Update()
    {
        Patrol();
        Move();
    }
    void Patrol()
    {
        if (points.Count == 0) return;
        if (Mathf.Abs(transform.position.x - points[currentPoint].position.x) < 0.1f)
        {
            currentPoint++;
            if (currentPoint >= points.Count)
            {
                currentPoint = 0;
            }
            ChangeDirection(points[currentPoint].position);
        }
    }
    void OnDrawGizmos()
    {
        if (points.Count == 0) return;
        Gizmos.color = Color.red;
        for (int i = 0; i < points.Count; i++)
        {
            Gizmos.DrawSphere(points[i].position, 0.1f);
        }
        Gizmos.color = Color.white;
        for (int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.DrawLine(points[i].position, points[i + 1].position);
        }

    }
}
