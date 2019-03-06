using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject playAgain;
    public GameObject quitGame;
    public GameObject winner;
    public GameObject loser;
    public GameObject timer;
    public GameObject resources;
    Scene scene1;

    private Town town;

    // Start is called before the first frame update
    void Start()
    {
        scene1 = SceneManager.GetActiveScene();
        //Time.timeScale = 1;
        //timer.SetActive(true);
        town = GameObject.FindGameObjectWithTag("town").GetComponent<Town>();
    }

    // Update is called once per frame
    void Update()
    {
        checkGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(scene1.name);
        //timer.SetActive(true);
        //resources.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
    public void checkGame()
    {
        if (town.gameOver)
        {
            //pause stuff
            Time.timeScale = 0;
            //GameObject UI = GameObject.Find("UI Script Manager");
            //UI.GetComponent<UI_Manager>().enabled = false;


            playAgain.SetActive(true);
            quitGame.SetActive(true);

            SceneManager.UnloadSceneAsync(scene1.name);
            //timer.SetActive(false);
            //resources.SetActive(false);

            if (true)
            {
                loser.SetActive(true);
            }

            if (false)
            {
                winner.SetActive(true);
            }


        }

    } 
}

