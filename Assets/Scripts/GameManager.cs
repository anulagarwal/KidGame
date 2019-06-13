using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsPaused;

    public GameObject PausePanel;
    public float RoundTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SaveSkill()
    {


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            TogglePause();
        }
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
