using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyObject;
    [SerializeField] private float spawnTime = 1f;
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemyObject, transform);    
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
