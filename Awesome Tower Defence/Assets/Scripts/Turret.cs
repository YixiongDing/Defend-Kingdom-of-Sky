using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public int price;
    public int sellPrice;

    [Header("Unity Settings")]

    public string EnemyTag = "Enemy";
    public float rotateSpeed = 10f;

    public GameObject bulletObject;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        float minDistance = Mathf.Infinity;
        GameObject targetEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                targetEnemy = enemy;
            }
        }
        if (targetEnemy != null && minDistance <= range)
        {
            //target = targetEnemy.transform;
            target = targetEnemy.GetComponent<GenericEnemy>().targetPosition;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 Rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(Rotation.x, Rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bullets = Instantiate(bulletObject, firePoint.position, firePoint.rotation);
        Bullet bullet = bullets.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.trace(target);
        }

    }

    void ONDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
