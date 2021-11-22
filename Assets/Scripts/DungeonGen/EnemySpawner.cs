using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;

    private int random;

    private bool spawned = true;

    public void Spawn()
    {
        if(spawned == true)
        {
            random = Random.Range(0, enemies.Length);
            Instantiate(enemies[random], transform.position, Quaternion.identity);

            spawned = false;
            Destroy(gameObject);
        }
        
    }
}
