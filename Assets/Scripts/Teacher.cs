
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.AI;

public class Teacher : MonoBehaviour
{

    public enum State { Idle, Walking, Search,Fall,GettingUp,Angry,ReallyAngry };
    public Animator anim;
    public State CurrentState;

    public List<Transform> PatrolPoints;

    public NavMeshAgent agent;

    public bool IsMoving;

    public int ToleranceLevel =0;

    public int CurrentPatrolPoint;
    public bool IsInPatrol;

    public float WaitTime;
    public float StartTime;
    public bool IsWaiting;

    public bool HasReacted;

    public float ReacionStartTime;

    public float GetUpTime;

    public bool IsGettingAngry;
    public Text ToleranceText;


    public Transform door;
    public bool IsLeaving;
    public GameObject WinGame;

    public bool IsGoingToObject;

    public Transform ObjectTarget;
    // Start is called before the first frame update
    void Start()
    {
        print("12");
        CurrentPatrolPoint = 0;
        StartPatrol();
        IsLeaving = false;
       // Move(PatrolPoints[CurrentPatrolPoint]);
    }
    public void IncreaseTolerance(int value)
    {
        ToleranceLevel += value;

    }
    // Update is called once per frame
    void Update()
    {

        ToleranceText.text = "Tolerance:" + ToleranceLevel;
 
        if (IsInPatrol && agent.remainingDistance<0.01f && !IsLeaving && !IsGoingToObject)
        {
            IsWaiting = true;
            StartTime = Time.time;
            IsInPatrol = false;
            UpdateState(State.Idle);

            //UpdatePatrolPosition();
        }
        if (IsWaiting && StartTime +WaitTime < Time.time && !IsLeaving && !IsGoingToObject)
        {
            IsInPatrol = true;
            IsWaiting = false;

            UpdatePatrolPosition();

        }

        if(IsGoingToObject && agent.remainingDistance< agent.stoppingDistance + 0.5f)
        {
            
            agent.stoppingDistance = 0f;
            ReallyAngry();
            IsGoingToObject = false;
        }
     
       // transform.rotation = Quaternion.Euler(Vector3.zero);
       if(HasReacted && ReacionStartTime + GetUpTime < Time.time )
        {

            if (!IsLeaving && !IsGoingToObject)
                EndReaction();
            else if (IsLeaving && !IsGoingToObject)
                QuitRoom();
            else if (!IsLeaving && IsGoingToObject)
                GotoObject();
        }

        if (ToleranceLevel > 95 && !IsLeaving)
        {
            IsLeaving = true;
            QuitRoom();
        }

        if(IsLeaving && agent.remainingDistance < 0.5f)
        {

            WinGame.SetActive(true);

        }
    }
    
    public void Move(Transform target)

    {
            UpdateState(State.Walking);
      //  transform.LookAt(target);
        agent.destination = target.position;

    }
    public void MoveTowardsObject(Transform target)
    {


    }
    public void Move(Vector3 target)

    {
        UpdateState(State.Walking);
        //  transform.LookAt(target);
        agent.destination = target;

    }

    public void StartPatrol()
    {
        UpdateState(State.Walking);

        IsInPatrol = true;
        Move(PatrolPoints[CurrentPatrolPoint]);
    }

    public void StopPatrol()
    {

        agent.isStopped = true;
        IsInPatrol = false;
    }
    public void Fall()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().MakeKidsLaugh();
        UpdateState(State.Fall);
        HasReacted = true;
        ReacionStartTime = Time.time;
        StopPatrol();
    }
    public void Angry(Vector3 target)
    {
        UpdateState(State.Angry);
        HasReacted = true;
        ReacionStartTime = Time.time;
        IsGoingToObject = true;

        StopPatrol();

    }

    public void GotoObject()
    {

        StartPatrol();
        Move(ObjectTarget);
        agent.stoppingDistance = 1f;

    }
    public void EndReaction()
    {

       
        agent.isStopped = false;
       // transform.GetChild(1). transform.localPosition = Vector3.zero;

       // UpdateState(State.GettingUp);
        //IsInPatrol = true;
       
        StartPatrol();

        HasReacted = false;
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
    public void ReallyAngry()

    {
        HasReacted = true;
        ReacionStartTime = Time.time;
        UpdateState(State.ReallyAngry);

    }
     void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);


        if (collision.gameObject.name == "Wax(Clone)" && collision.gameObject.GetComponent<Obstacle>().hasPlaced==true)
        {
        Destroy(collision.gameObject);
            IncreaseTolerance(15);
            Fall();
        }
        else if(collision.gameObject.name == "Gum(Clone)" && collision.gameObject.GetComponent<Obstacle>().hasPlaced == true)
        {
        Destroy(collision.gameObject);
            IncreaseTolerance(25);
            Fall();
        }

    }

    public void QuitRoom()
    {
        agent.isStopped = false;
        UpdateState(State.Walking);
        IsInPatrol = false;
        Move(door);

    }
    public void UpdateState(State state)
    {
        switch (state)
        {

            case State.Walking:
                anim.Play("Walking");
                CurrentState = State.Walking;
                break;


            case State.Idle:
                anim.Play("Idle");
                CurrentState = State.Idle;

                break;

            case State.Search:

                break;
            case State.Fall:
                anim.Play("Fall");
                break;
            case State.GettingUp:
                anim.Play("GetUp");
                break;
            case State.Angry:
                anim.Play("Angry");
                break;
            case State.ReallyAngry:
                anim.Play("ReallyAngry");
                break;
        }
    }
}
