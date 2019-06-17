using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsPaused;

    public GameObject PausePanel;
    public float RoundTime;
    public Transform CameraOriginalPos;
    public Transform CameraChangePos;
    public GameObject GumUI;
    public GameObject WaxUI;
    public GameObject Gum;

    public GameObject Wax;
   
    public bool IsSelectorOn;
    public GameObject SkillPanel;
    public Transform CurrentSelect;

    public List<NPC> characters;
    // Start is called before the first frame update
    void Start()
    {
   
    }
    public void SaveSkill()
    {


    }
    int Rand;
    int Lenght;
    List<int> list = new List<int>();

    void Generate()
    {
        Lenght = 5;
        list = new List<int>(new int[Lenght]);

        for (int j = 1; j < Lenght; j++)
        {
            Rand = Random.Range(0, characters.Count);

            while (list.Contains(Rand))
            {
                Rand = Random.Range(1, 6);
            }

            list[j] = Rand;
         
        }
        int i = 0;
        while (i < list.Count)
        {
            characters[list[i]].MakeLaugh() ;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Start");
            SkillPanel.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            TogglePause();
        }
        if (IsSelectorOn)
        {

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);

           
                Vector3 wordPos;
                Ray ray = Camera.main.ScreenPointToRay(mousePos);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000f))
                {
                    wordPos = hit.point;
                if (hit.collider.name == "Floor")
                {

                    CurrentSelect.position = wordPos;
                }
                }
            else
                {
                    wordPos = Camera.main.ScreenToWorldPoint(mousePos);
                }
         
            //or for tandom rotarion use Quaternion.LookRotation(Random.insideUnitSphere)
            if (Input.GetMouseButtonDown(0))
            {
                CurrentSelect.GetComponent<Obstacle>().hasPlaced = true;
                IsSelectorOn = false;
                DisableSetup();
            }
        }
    }
    public void MakeKidsLaugh()
    {
        Generate();

    }
    public void TogglePause()
    {

        if (IsPaused)
        {

            PauseGame();
        }
       
        else
        {

            UnPauseGame();
        }

    }
    public void SetPlayerSkill(int number)
    {

        GameObject.Find("Character").GetComponent<Character>().SetSkill(number);

        if(number == 1)
        {

            GumUI.SetActive(true);
            EnableSetup(number);
        }

        else if (number == 2)
        {
            WaxUI.SetActive(true);
            EnableSetup(number);
        }

       
    }

    public void EnableSetup(int skill)
    {

        //Change camera angle to class top view
        //Bring up UI and instantiate a gameobject 
        //Set position to cursor
        //On click drop object 
        //change camera view
        //Close UI and start game
        // GetComponent<UIManager>().CloseSetup();
        SkillPanel.SetActive(false);
        Camera.main.GetComponent<MouseLook>().enabled = false;
        Camera.main.transform.position = CameraChangePos.position;
        Camera.main.transform.rotation = CameraChangePos.rotation;
        if (skill == 1)
        {
            GameObject go = Instantiate(Gum, Input.mousePosition, Quaternion.identity);
            CurrentSelect = go.transform;
        }

        else if (skill == 2)
        {
            GameObject go = Instantiate(Wax, Input.mousePosition, Quaternion.identity);
            //transform.localScale = new Vector3(0.0005f, 0.001f, 0.0005f);
            CurrentSelect = go.transform;

        }
        IsSelectorOn = true;

    }


    public void DisableSetup()
    {

        Camera.main.transform.position = CameraOriginalPos.position;
        Camera.main.transform.rotation = CameraOriginalPos.rotation;
        Camera.main.GetComponent<MouseLook>().enabled = true;

        WaxUI.SetActive(false);
        GumUI.SetActive(false);


    }
    public void PauseGame()
    {
        PausePanel.SetActive(true);
        IsPaused = true;
    }

    public void UnPauseGame()
    {

        PausePanel.SetActive(false);
        IsPaused = false;

    }
}
