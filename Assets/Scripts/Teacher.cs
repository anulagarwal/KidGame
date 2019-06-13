
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teacher : MonoBehaviour
{

    public enum State { Idle, Walking, Search };
    public Animator anim;
    public State CurrentState;

    public List<Transform> PatrolPoints;

    public NavMeshAgent agent;

    public bool IsMoving;

    public int ToleranceLevel;

    public int CurrentPatrolPoint;
    public bool IsInPatrol;

    public float WaitTime;
    public float StartTime;
    public bool IsWaiting;
    // Start is called before the first frame update
    void Start()
    {
        print("12");

        StartPatrol();
       // Move(PatrolPoints[CurrentPatrolPoint]);
    }

    // Update is called once per frame
    void Update()
    {
        print(agent.isStopped);
        if (IsInPatrol && agent.remainingDistance<0.01f)
        {
            IsWaiting = true;
            StartTime = Time.time;
            IsInPatrol = false;
            UpdateState(State.Idle);

            //UpdatePatrolPosition();
        }
        if (IsWaiting && StartTime +WaitTime < Time.time)
        {
            IsInPatrol = true;
            IsWaiting = false;

            UpdatePatrolPosition();

        }
    }

    public void Move(Transform target)

    {
            UpdateState(State.Walking);

        agent.destination = target.position;

    }
    public void StartPatrol()
    {
        UpdateState(State.Walking);
        CurrentPatrolPoint = 0;

        IsInPatrol = true;
        Move(PatrolPoints[CurrentPatrolPoint]);
    }

    public void UpdatePatrolPosition()
    {
        CurrentPatrolPoint++;
        if (CurrentPatrolPoint < PatrolPoints.Count)
        {

        }
        else
        {
            CurrentPatrolPoint = 0;

        }

        Move(PatrolPoints[CurrentPatrolPoint]);
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
