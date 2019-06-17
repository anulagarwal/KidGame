
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public enum State { Idle,Idle2, Clapping, Search,Laughing,Laughing2,Laughing3,Laughing4,Laughing5,Writing };
    public Animator anim;
    public State CurrentState;

    public float ChangeStartTime;
    public float delayTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //UpdateState(State.Idle);
        ChangeStartTime = Time.time;
        delayTime = Random.Range(2,5);
    }

    // Update is called once per frame
    void Update()
    {
        if(ChangeStartTime + delayTime < Time.time)
        {

            if (Random.Range(0, 100) > 40)
            {
                delayTime = Random.Range(5, 8);
                ChangeStartTime = Time.time;

                //GoIdleOrGoWrite();
            }
        }
    }
    public void ChangeMood()
    {
        GoIdle();

    }
    public void MakeLaugh()
    {
        int random = Random.Range(0, 5);
        switch (random)
        {
            case 1:
                UpdateState(State.Laughing);
                break;

            case 2:
                UpdateState(State.Laughing2);

                break;
            case 3:
                UpdateState(State.Laughing3);

                break;
            case 4:
                UpdateState(State.Laughing4);

                break;
            case 5:
                UpdateState(State.Laughing5);

                break;

        }

    }

    public void GoIdle()
    {
        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                UpdateState(State.Idle);
                break;

            case 1:
                UpdateState(State.Idle2);

                break;
                
        }
        print(random);
    }


    public void GoIdleOrGoWrite()
    {
        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                GoIdle() ;
                break;

            case 1:
                GoWrite();

                break;

        }

    }

    public void GoWrite ()
    {

        UpdateState(State.Writing);
    }
    public void UpdateState(State state)
    {
        switch (state)
        {

            case State.Clapping:

                anim.Play("Clap");
                break;


            case State.Idle:
                anim.Play("Idle");

                break;
            case State.Idle2:
                anim.Play("Idle2");

                break;

            case State.Search:
                anim.Play("Search");

                break;
            case State.Laughing:
                anim.Play("Laughing");

                break;

            case State.Laughing2:
                anim.Play("Laughing2");

                break;
            case State.Laughing3:
                anim.Play("Laughing3");

                break;
            case State.Laughing4:
                anim.Play("Laughing4");

                break;
            case State.Laughing5:
                anim.Play("Laughing5");

                break;

            case State.Writing:
                anim.Play("Writing");

                break;
        }
    }
}
