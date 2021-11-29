using UnityEngine;
using UnityEngine.UI;
public class AbilityUI : MonoBehaviour
{
    public GameObject player;
    public Ability[] abilities;
    AbilityHolder abilityHolder;
    public float[] cooldowns;
    public bool[] abilityInput;
    public bool[] isCooldown;

    public Image[] abilityImages;


    private void Awake()
    {
        abilityHolder = player.GetComponent<AbilityHolder>();
        abilities[0] = player.GetComponent<AbilityHolder>().abilities[0];
        abilities[1] = player.GetComponent<AbilityHolder>().abilities[1];
        abilities[2] = player.GetComponent<AbilityHolder>().abilities[2];
        abilities[3] = player.GetComponent<AbilityHolder>().abilities[3];
        
        cooldowns[0] = abilities[0].cooldownTime;
        cooldowns[1] = abilities[1].cooldownTime;
        cooldowns[2] = abilities[2].cooldownTime;
        cooldowns[3] = abilities[3].cooldownTime;

        abilityImages[0].fillAmount = 0;
        abilityImages[1].fillAmount = 0;
        abilityImages[2].fillAmount = 0;
        abilityImages[3].fillAmount = 0;

        abilityInput[0] = false;
        abilityInput[1] = false;
        abilityInput[2] = false;
        abilityInput[3] = false;

        isCooldown[0] = false;
        isCooldown[1] = false;
        isCooldown[2] = false;
        isCooldown[3] = false;
    }

    public void Update()
    {
        if(abilityInput[0] == true && isCooldown[0] == false)
        {
            abilityImages[0].fillAmount = 1;
            isCooldown[0] = true;
        }
        if (abilityInput[1] == true && isCooldown[1] == false)
        {
            abilityImages[1].fillAmount = 1;
            isCooldown[1] = true;
        }
        if (abilityInput[2] == true && isCooldown[2] == false)
        {
            abilityImages[2].fillAmount = 1;
            isCooldown[2] = true;
        }
        if (abilityInput[3] == true && isCooldown[3] == false)
        {
            abilityImages[3].fillAmount = 1;
            isCooldown[3] = true;
        }



        Ability1();
        Ability2();
        Ability3();
        Ability4();
    }

    void Ability1()
    {


        if (isCooldown[0] == true)
        {
            abilityImages[0].fillAmount -= 1 / cooldowns[0] * Time.deltaTime;

            if(abilityImages[0].fillAmount <= 0)
            {
                abilityImages[0].fillAmount = 0;
                abilityInput[0] = false;
                isCooldown[0] = false;
            }
        }

    }
    void Ability2()
    {


        if (isCooldown[1] == true)
        {
            abilityImages[1].fillAmount -= 1 / cooldowns[1] * Time.deltaTime;

            if (abilityImages[1].fillAmount <= 0)
            {
                abilityImages[1].fillAmount = 0;
                abilityInput[1] = false;
                isCooldown[1] = false;
            }
        }

    }
    void Ability3()
    {


        if (isCooldown[2] == true)
        {
            abilityImages[2].fillAmount -= 1 / cooldowns[2] * Time.deltaTime;

            if (abilityImages[2].fillAmount <= 0)
            {
                abilityImages[2].fillAmount = 0;
                abilityInput[2] = false;
                isCooldown[2] = false;
            }
        }

    }
    void Ability4()
    {


        if (isCooldown[3] == true)
        {
            abilityImages[3].fillAmount -= 1 / cooldowns[3] * Time.deltaTime;

            if (abilityImages[3].fillAmount <= 0)
            {
                abilityImages[3].fillAmount = 0;
                abilityInput[3] = false;
                isCooldown[3] = false;
            }
        }

    }
}
