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

    Scene scene1;

    private Town town;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        scene1 = SceneManager.GetActiveScene();
        town = GameObject.FindGameObjectWithTag("town").GetComponent<Town>();
    }

    // Update is called once per frame
    void Update()
    {
        checkGame();
        //Debug.Log(Time.timeScale);
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene("dillon test");
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

            if (false)
            {
                winner.SetActive(true);
            }


        }

    } 
}

