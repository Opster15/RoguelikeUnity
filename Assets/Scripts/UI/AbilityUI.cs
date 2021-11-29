using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbilityUI : MonoBehaviour
{
    public GameObject player;
    Ability ability;
    AbilityHolder abilityHolder;
    public float cooldown1;
    public bool abilityInput = false;
    public bool isCooldown = false;

    public Image abilityImage1;


    private void Awake()
    {
        ability = player.GetComponent<AbilityHolder>().ability;
        abilityHolder = player.GetComponent<AbilityHolder>();
        cooldown1 = ability.cooldownTime;
        abilityImage1.fillAmount = 0;
    }

    public void Update()
    {
        if(abilityInput == true && isCooldown == false)
        {
            abilityImage1.fillAmount = 1;
            isCooldown = true;
        }

        Ability1();
    }

    void Ability1()
    {


        if (isCooldown == true)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                abilityInput = false;
                isCooldown = false;
            }
        }

    }
}
