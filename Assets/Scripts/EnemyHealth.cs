using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth,maxHealth;

    public Animator anim;

    public void Awake()
    {
        currentHealth = maxHealth;
    }


    void Update()
    {
        /*
        if (inputManager.spacePressed)
        {
            TakeDamage(150);
        }
        */
        if (currentHealth <= 0)
        {
            Debug.Log("DIE");
            anim.SetBool("IsDead", true);
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}