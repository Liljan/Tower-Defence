using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public float range = 15.0f;
    private float range2;

    public float turnSpeed = 10.0f;

    private bool isAlive = true;
    private bool isSearching = false;

    // Use this for initialization
    void Start()
    {
        range2 = range * range;
        StartCoroutine(SearchForEnemy(0.5f));
    }

    // Update is called once per frame
    void Update()
    {

        if (target)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);

            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

    }

    private IEnumerator SearchForEnemy(float dt)
    {
        while (true)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            GameObject nearestEnemy = null;
            float shortest = Mathf.Infinity;

            for (int i = 0; i < enemies.Length; i++)
            {
                float dist2 = DistSquared(enemies[i].transform.position, transform.position);

                if (dist2 < shortest)
                {
                    shortest = dist2;
                    nearestEnemy = enemies[i];
                }
            }

            if (nearestEnemy != null && shortest <= range2)
            {
                target = nearestEnemy.transform;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void UpdateTarget()
    {

    }

    private float DistSquared(Vector3 a, Vector3 b)
    {
        float res = 0.0f;
        res += (a.x - b.x) * (a.x - b.x);
        res += (a.y - b.y) * (a.y - b.y);
        res += (a.z - b.z) * (a.z - b.z);
        return res;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
