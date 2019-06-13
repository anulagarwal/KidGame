using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update

    public enum State { Idle, Walking, Search };
    public Animator anim;
    public State CurrentState;

    public List<Transform> PatrolPoints;

   

    public bool IsMoving;

    public int ToleranceLevel;

    public int CurrentPatrolPoint;
    public bool IsInPatrol;

    public float WaitTime;
    public float StartTime;
    public bool IsWaiting;

    public int CheatLevel;
    // Start is called before the first frame update
    void Start()
    {
        

      
        // Move(PatrolPoints[CurrentPatrolPoint]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {


        }
    }

   
    
    public void UpdateState(State state)
    {
        switch (state)
        {

            case State.Walking:
                anim.Play("Walking");

                break;


            case State.Idle:
                anim.Play("Idle");

                break;

            case State.Search:

                break;


        }
    }
}
