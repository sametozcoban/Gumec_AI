using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class HealthEnemy : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    [SerializeField] int enemyHealth = 50;
    [Tooltip("Adds amount to maxHitPoint when enemy dies")]
    [SerializeField] private int difficultyRamp = 1;

    int currentHitPoints = 0;
    Enemy _enemy;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoint;
    }

    void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        EnemyHit();
    }

    public void EnemyHit()
    {
        enemyHealth -= currentHitPoints;

        if (enemyHealth <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoint += difficultyRamp;
            _enemy.GoldReward();
        }
    }
}
