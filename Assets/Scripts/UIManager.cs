using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject IntroductionPanel;
    public Text currentTime ;
    public float CurrentTime = 90;

    public GameObject LosePanel;
    // Start is called before the first frame update
    void Start()
    {
        IntroductionPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= Time.deltaTime;
        if (CurrentTime < 0)
        {
            GameOver();
        }

        currentTime.text = "" + Mathf.RoundToInt( CurrentTime);
        if (CurrentTime < 1)
        {

            LoseGame();
        }
    }

    public void LoseGame()
    {
        LosePanel.SetActive(true);

    }

    public void CloseSetup()
    {

        IntroductionPanel.SetActive(false);

    }

    public void GameOver()
    {


    }

}
