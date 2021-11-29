using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{

    public Ability[] abilities;
    public AbilityUI ui;
    public float[] cooldownTime;
    public float[] activeTime;

    #region Ability Enums   

    public enum Ability1State
    {
        ready,
        active,
        cooldown
    }
    public enum Ability2State
    {
        ready,
        active,
        cooldown
    }
    public enum Ability3State
    {
        ready,
        active,
        cooldown
    }
    public enum Ability4State
    {
        ready,
        active,
        cooldown
    }
    #endregion

    Ability1State state1 = Ability1State.ready;
    Ability2State state2 = Ability2State.ready;
    Ability3State state3 = Ability3State.ready;
    Ability4State state4 = Ability4State.ready;


    private void Update()
    {
        Ability1();
        Ability2();
        Ability3();
        Ability4();
    }

    void Ability1()
    {
        #region ability1
        switch (state1)
        {
            case Ability1State.ready:
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    abilities[0].Activate(gameObject);
                    state1 = Ability1State.active;
                    activeTime[0] = abilities[0].activeTime;
                }
                return;
            case Ability1State.active:
                if (activeTime[0] > 0)
                {
                    activeTime[0] -= Time.deltaTime;
                }
                else
                {
                    state1 = Ability1State.cooldown;
                    cooldownTime[0] = abilities[0].cooldownTime;
                    ui.abilityInput[0] = true;
                }
                return;
            case Ability1State.cooldown:
                if (cooldownTime[0] > 0)
                {
                    cooldownTime[0] -= Time.deltaTime;
                }
                else
                {
                    state1 = Ability1State.ready;
                }
                return;
                
        }
        #endregion
    }

    void Ability2()
    {
        #region ability2
        switch (state2)
        {
            case Ability2State.ready:
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    abilities[1].Activate(gameObject);
                    state2 = Ability2State.active;
                    activeTime[1] = abilities[1].activeTime;
                }
                return;
            case Ability2State.active:
                if (activeTime[1] > 0)
                {
                    activeTime[1] -= Time.deltaTime;
                }
                else
                {
                    state1 = Ability1State.cooldown;
                    cooldownTime[1] = abilities[1].cooldownTime;
                    ui.abilityInput[1] = true;
                }
                return;
            case Ability2State.cooldown:
                if (cooldownTime[1] > 0)
                {
                    cooldownTime[1] -= Time.deltaTime;
                }
                else
                {
                    state2 = Ability2State.ready;
                }
                return;

        }
        #endregion
    }
    void Ability3()
    {
        #region ability3
        switch (state3)
        {


            case Ability3State.ready:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    abilities[2].Activate(gameObject);
                    state3 = Ability3State.active;
                    activeTime[2] = abilities[2].activeTime;
                }
                return;
            case Ability3State.active:
                if (activeTime[2] > 0)
                {
                    activeTime[2] -= Time.deltaTime;
                }
                else
                {
                    state3 = Ability3State.cooldown;
                    cooldownTime[2] = abilities[2].cooldownTime;
                    ui.abilityInput[2] = true;
                }
                return;
            case Ability3State.cooldown:
                if (cooldownTime[2] > 0)
                {
                    cooldownTime[2] -= Time.deltaTime;
                }
                else
                {
                    state3 = Ability3State.ready;
                }
                return;

        }
        #endregion
    }
    void Ability4()
    {
        #region ability4
        switch (state4)
        {


            case Ability4State.ready:
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    abilities[3].Activate(gameObject);
                    state4 = Ability4State.active;
                    activeTime[3] = abilities[3].activeTime;
                }
                return;
            case Ability4State.active:
                if (activeTime[3] > 0)
                {
                    activeTime[3] -= Time.deltaTime;
                }
                else
                {
                    state4 = Ability4State.cooldown;
                    cooldownTime[3] = abilities[3].cooldownTime;
                    ui.abilityInput[3] = true;
                }
                return;
            case Ability4State.cooldown:
                if (cooldownTime[3] > 0)
                {
                    cooldownTime[3] -= Time.deltaTime;
                }
                else
                {
                    state4 = Ability4State.ready;
                }
                return;

        }
        #endregion
    }
}
