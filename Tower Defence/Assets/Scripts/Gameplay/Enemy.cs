using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;

    private Transform target;
    private int waypointIndex = 0;
    private int AMOUNT_WAYPOINTS;

    // Use this for initialization
    void Start()
    {
        target = Waypoint.points[0];
        AMOUNT_WAYPOINTS = Waypoint.points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - this.transform.position;
        this.transform.Translate(dir.normalized * speed * Time.deltaTime);


        if (DistSquared(transform.position, target.position) < 1.0f)
        {
            GetNextWayPoint();
        }
    }

    private float DistSquared(Vector3 a, Vector3 b)
    {
        float res = 0.0f;
        res += (a.x - b.x) * (a.x - b.x);
        res += (a.y - b.y) * (a.y - b.y);
        res += (a.z - b.z) * (a.z - b.z);
        return res;
    }

    private void GetNextWayPoint()
    {
        if (waypointIndex >= AMOUNT_WAYPOINTS - 1)
        {
            Destroy(gameObject);
            return;
        }

        ++waypointIndex;
        target = Waypoint.points[waypointIndex];
    }
}
