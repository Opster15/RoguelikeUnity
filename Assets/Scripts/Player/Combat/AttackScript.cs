using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public GameObject hitPoint,hitEffect;

    public LayerMask whatIsEnemies;

    public int damage;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Collider[] enemies = Physics.OverlapSphere(hitPoint.transform.position, range, whatIsEnemies);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                GameObject hit = (GameObject)Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(hit, 1.0f);
            }
        }
    }
}
