using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MeleeSettings")]
public class MeleeWeapons : ScriptableObject
{
    public int damage;
    public float range,timeBewtweenAttacks;

    public GameObject weaponPrefab;

}