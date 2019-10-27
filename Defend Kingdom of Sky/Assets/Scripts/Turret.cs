using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    private GenericEnemy targetEnemy;

    [Header("General")]
    public int price;
    public int upgradePrice;
    public int sellPrice;
    public int type; // 0 for connon turret, 1 for laser turret
    public bool isUpgraded = false;

    [Header("Use Bullets (default)")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;

    //public int damageOverTime = 30;
    public float slowAmount = .5f;

    public LineRenderer lineRenderer;
    //public ParticleSystem impactEffect;
    //public Light impactLight;

    [Header("Unity Settings")]

    public string EnemyTag = "Enemy";
    public float rotateSpeed = 10f;

    public GameObject bulletObject;
    public Transform firePoint;
    public Transform firePoint_;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        //float minDistance = Mathf.Infinity;
        //GameObject targetEnemy = null;
        //foreach (GameObject enemy in enemies)
        //{
        //    float distance = Vector3.Distance(transform.position, enemy.transform.position);
        //    if (distance < minDistance)
        //    {
        //        minDistance = distance;
        //        targetEnemy = enemy;
        //    }
        //}
        //if (targetEnemy != null && minDistance <= range)
        //{
        //    //target = targetEnemy.transform;
        //    target = targetEnemy.GetComponent<GenericEnemy>().targetPosition;
        //}
        //else
        //{
        //    target = null;
        //}
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            if (useLaser)
            {
                target = nearestEnemy.transform;
                targetEnemy = nearestEnemy.GetComponent<GenericEnemy>();
                targetEnemy.gameObject.GetComponent<EnemyMovement>().ResetSpeed();
            }
            else
            {
                target = nearestEnemy.GetComponent<GenericEnemy>().targetPosition;
                targetEnemy = nearestEnemy.GetComponent<GenericEnemy>();
                targetEnemy.gameObject.GetComponent<EnemyMovement>().ResetSpeed();
            }
            
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    //impactEffect.Stop();
                    //impactLight.enabled = false;
                }
            }
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            lineRenderer.enabled = true;
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
        //Vector3 dir = target.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 Rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        //transform.rotation = Quaternion.Euler(Rotation.x, Rotation.y, 0f);

        //if (fireCountdown <= 0f)
        //{
        //    Shoot();
        //    fireCountdown = 1f / fireRate;
        //}

        //fireCountdown -= Time.deltaTime;
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);
    }

    void Laser()
    {
        targetEnemy.gameObject.GetComponent<EnemyMovement>().Slow(slowAmount);

        //if (!lineRenderer.enabled)
        //{
        //    lineRenderer.enabled = true;
        //    impactEffect.Play();
        //    impactLight.enabled = true;
        //}

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        //Vector3 dir = firePoint.position - target.position;

        //impactEffect.transform.position = target.position + dir.normalized;

        //impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }


    void Shoot()
    {
        if (firePoint != null)
        {
            GameObject bullets = Instantiate(bulletObject, firePoint.position, firePoint.rotation);
            Bullet bullet = bullets.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.trace(target);
            }
        }
        if (firePoint_ != null)
        {
            GameObject bullets_ = Instantiate(bulletObject, firePoint_.position, firePoint_.rotation);
            Bullet bullet_ = bullets_.GetComponent<Bullet>();
            if (bullet_ != null)
            {
                bullet_.trace(target);
            }
        }
    }

    void ONDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
