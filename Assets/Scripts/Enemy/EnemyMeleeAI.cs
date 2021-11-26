using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAI : MonoBehaviour
{
    public float lookRadius,attackRadius,speed;
    public LayerMask whatIsPlayer;
    Animator anim;

    Transform target;

    private enum State
    {
        Idle,
        Moving,
        Dead
    }

    private State currentState;

    private void Start()
    {
        anim = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
    }


    private void Update()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            case State.Idle:
                UpdateIdleState();
                break;
            case State.Moving:
                UpdateMovingState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;
        }

    }

    //MOVING

    private void EnterIdleState()
    {


    }


    private void UpdateIdleState()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            SwitchState(State.Moving);
            currentState = State.Moving;
        }

    }

    private void ExitIdleState()
    {

    }


    //KNOCKBACK

    private void EnterMovingState()
    {

    }


    private void UpdateMovingState()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            SwitchState(State.Idle);
            currentState = State.Idle;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
    }

    private void ExitMovingState()
    {

    }


    //DEAD

    private void EnterDeadState()
    {
        Destroy(gameObject);
    }


    private void UpdateDeadState()
    {

    }

    private void ExitDeadState()
    {

    }




    private void SwitchState(State state)
    {
        switch (currentState)
        {
            case State.Idle:
                ExitIdleState();
                break;
            case State.Moving:
                ExitMovingState();
                break;
            case State.Dead:
                ExitDeadState();
                break;
        }

        switch (state)
        {
            case State.Idle:
                EnterIdleState();
                break;
            case State.Moving:
                EnterMovingState();
                break;
            case State.Dead:
                EnterDeadState();
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
