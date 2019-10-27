using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;
    private float speed_;
    private Transform target;
    private int wavepointIndex = 0;
    void Start()
    {
        speed_ = speed;
        target = Waypoints.points[0];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed_ * Time.deltaTime, Space.World);
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 Rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speed_).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, Rotation.y, 0f);
        if (Vector3.Distance(transform.position, target.position) <= 2.0f)
        {
            GetNextWaypoint();
        }
    }

    public void Slow(float pct)
    {
        speed_ = speed_ * (1f - pct);
    }

    public void ResetSpeed()
    {
        speed_ = speed;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
        }
        else
        {
            wavepointIndex++;
            target = Waypoints.points[wavepointIndex];
        }
    }
}