
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Transform target)

    {

        agent.destination=target.position;

    }
    public void UpdateState(State state)
    {
        switch (state)
        {

            case State.Walking:


                break;


            case State.Idle:

                break;

            case State.Search:

                break;


        }
    }
}
