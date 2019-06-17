using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Character : MonoBehaviour
{
    // Start is called before the first frame update

    public enum State { Idle, Walking, Search };
    public Animator anim;
    public State CurrentState;
    
   
    
    public int ToleranceLevel;


    public float CheatLevel;
    public Slider cheatBar;
    int skill;
    public GameObject PaperBall;
    public GameObject SkillPanel;
    public List<GameObject> ThrowableObjects;

    public float ThrowCooldown;
    public float CooldownStartTime;
    public bool CanThrow;
    public Text CooldownText;
    // Start is called before the first frame update
    void Start()
    {
        

            cheatBar.maxValue = 3;
        
        // Move(PatrolPoints[CurrentPatrolPoint]);
    }

    // Update is called once per frame
    void Update()
    {
        if(CooldownStartTime + ThrowCooldown - Time.time>0)
        CooldownText.text = "Cooldown: " + (Mathf.RoundToInt(CooldownStartTime + ThrowCooldown - Time.time));
        else
        {
            CooldownText.text = "Cooldown: 0";

        }
        if (Input.GetKey(KeyCode.LeftShift))

        {

            IncreaseCheatBar(0.01f);

            
        }
      
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            ThrowPaperBall();

        }

        if(!CanThrow && CooldownStartTime+ThrowCooldown < Time.time)
        {
            CanThrow = true;
        }


    }

    public void SetSkill(int number)
    {
        skill = number;

    }
    public void ThrowPaperBall()
    {

        if (CanThrow)
        {
            CooldownStartTime = Time.time;
            CanThrow = false;
            //Instantiate and throw paper ball at teacher randomly
            GameObject go = Instantiate(ThrowableObjects[Random.Range(0, ThrowableObjects.Count)], Camera.main.transform.position, Quaternion.identity);

        }
    }
   public void IncreaseCheatBar(float value)
    {
        CheatLevel+=value;
        cheatBar.value = CheatLevel ;
      
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
