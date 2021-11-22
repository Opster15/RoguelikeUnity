using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Vector3 com;
    public Rigidbody rb;

    public float torque;

    public GameObject enemy;

    public int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com;

        rb.AddTorque(transform.right * torque);

        Destroy(gameObject, 8f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }


}
