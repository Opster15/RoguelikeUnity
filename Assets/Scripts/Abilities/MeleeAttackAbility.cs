using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MeleeAttackAbility : Ability
{
    public float range,attackKnockback;
    public int damage;
    public LayerMask whatIsEnemy;
    public RaycastHit rayHit;
    public Camera cam;

    private void Awake()
    {

    }

    public override void Activate(GameObject child)
    {
        Camera cam = child.GetComponentInChildren<Camera>();
        Vector3 direction = cam.transform.forward;

        if (Physics.Raycast(cam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            
            if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
                rayHit.collider.GetComponent<Rigidbody>().AddExplosionForce(attackKnockback, cam.transform.position, range);
            }
        }

    }
}
