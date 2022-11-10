using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] float range = 15f;
    [SerializeField] Transform weapon;
    
    Transform target;
    
    // Update is called once per frame
    void Update()
    {
        ClosestTarget();
        weaponFollow();
    }

    void ClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;

    }
    
    void weaponFollow()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);

        if (targetDistance < range)
        {
            AttackParticles(true);
        }
        else
        {
            AttackParticles(false);
        }
    }

    void AttackParticles(bool isActive)
    {
        var emissionModule = _particleSystem.emission;
        emissionModule.enabled = isActive;
    }
    
}
