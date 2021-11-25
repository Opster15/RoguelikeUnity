using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public GameObject hitPoint,hitEffect;


    public MeleeWeapons weapon;

    public Animator anim;

    public LayerMask whatIsEnemies;

    bool readyToAttack;

    public bool allowInvoke = true;

    // Start is called before the first frame update
    void Start()
    {
        readyToAttack = true;
        GameObject weaponClone = Instantiate(weapon.weaponPrefab, transform.position, Quaternion.identity);
        weaponClone.transform.parent = gameObject.transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && readyToAttack == true)
        {
            anim.SetBool("IsAttacking", true);
            readyToAttack = false;

            Collider[] enemies = Physics.OverlapSphere(hitPoint.transform.position, weapon.range, whatIsEnemies);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyHealth>().TakeDamage(weapon.damage);
                GameObject hit = (GameObject)Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(hit, 1.0f);
            }

            if (allowInvoke)
            {
                Invoke("Reset", weapon.timeBewtweenAttacks);
                allowInvoke = false;
            }
        }


    }

    private void Reset()
    {
        readyToAttack = true;
        allowInvoke = true;
        anim.SetBool("IsAttacking", false);
    }
}
