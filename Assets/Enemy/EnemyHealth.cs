using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoint = 10;
    
    [Tooltip("Adds max health to new enemies when one dies")]
    [SerializeField] private int difficultyRamp = 1;
    
    private int currentHp = 10;
    private Enemy enemy;
    // Start is called before the first frame update
    private void OnEnable()
    {
        currentHp = maxHitPoint;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHp--;
        if (currentHp < 1)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
            maxHitPoint += difficultyRamp;
        }
    }
}
