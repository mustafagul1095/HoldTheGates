using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoint = 10;
    private int currentHp = 10;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHitPoint;
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
            Destroy(gameObject);
        }
    }
}
