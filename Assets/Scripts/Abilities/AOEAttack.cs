using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AOEAttack : Ability
{

    public float attackRadius,attackForce;
    public int damage;
    public LayerMask whatIsEnemy;
    public GameObject effect;

    public override void Activate(GameObject child)
    {
        Collider[] enemies = Physics.OverlapSphere(child.transform.position, attackRadius, whatIsEnemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyHealth>().TakeDamage(damage);
            enemies[i].GetComponent<Rigidbody>().AddExplosionForce(attackForce, child.transform.position, attackRadius);
        }
        GameObject hit = (GameObject)Instantiate(effect, child.transform.position, Quaternion.identity);
        Destroy(hit, activeTime);
    }
}
