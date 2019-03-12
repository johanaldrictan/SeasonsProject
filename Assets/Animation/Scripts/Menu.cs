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
    public GameObject commander;
    public GameObject Canvas;
    public bool inEscape;
    public bool gameOver;
    public GameObject escape;

    Scene scene1;

    private Town town;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        scene1 = SceneManager.GetActiveScene();
        town = GameObject.FindGameObjectWithTag("town").GetComponent<Town>();
        inEscape = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkGame();
        //Debug.Log(Time.timeScale);

        if (Input.GetKeyDown(KeyCode.Escape) && !inEscape && !gameOver)
        {
            showEscape();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && inEscape)
        {
            hideEscape();
        }
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(scene1.name);

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
            Canvas.SetActive(false);
            commander.SetActive(false);

            //menu appear
            playAgain.SetActive(true);
            quitGame.SetActive(true);
            

            if (true)
            {
                loser.SetActive(true);
            }

            //if (false)
            //{
            //    winner.SetActive(true);
            //}

            gameOver = true;

        }

    } 

    public void showEscape()
    {
        //escape.SetActive(true);
        inEscape = true;
        Time.timeScale = 0;
        Canvas.SetActive(false);
        commander.SetActive(false);
        escape.GetComponent<CanvasGroup>().interactable = true;
        escape.GetComponent<CanvasGroup>().alpha = 1;
    }

    public void hideEscape()
    {
        //escape.SetActive(false);
        inEscape = false;
        Time.timeScale = 1;
        Canvas.SetActive(true);
        commander.SetActive(true);
        escape.GetComponent<CanvasGroup>().interactable = false;
        escape.GetComponent<CanvasGroup>().alpha = 0;

    }
}

