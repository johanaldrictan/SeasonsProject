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
    private bool notPlaying;
    public bool inMainMenu;
    public GameObject escape;
    public AudioClip endingMusic;

    private AudioSource PlaySource;

    Scene scene1;

    private Town town;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        scene1 = SceneManager.GetActiveScene();
        if (!inMainMenu) 
            town = GameObject.FindGameObjectWithTag("town").GetComponent<Town>();
        inEscape = false;
        gameOver = false;
        notPlaying = true;
        PlaySource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inMainMenu)
        {
            checkGame();
        }
        //Debug.Log(Time.timeScale);

        if (Input.GetKeyDown(KeyCode.Escape) && !inEscape && !gameOver)
        {
            showEscape();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && inEscape)
        {
            hideEscape();
        }

        if (gameOver && notPlaying)
        {
            PlaySource.clip = this.endingMusic;
            PlaySource.volume = 0.7f;
            PlaySource.Play();
            notPlaying = false;
        }
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void StartGame()
    {
        notPlaying = true;
        PlaySource.volume = 1.0f;
        SceneManager.LoadScene(scene1.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
    public void checkGame()
    {
        if (town.gameOver || Season.instance.year == 3)
        {
            //pause stuff
            Time.timeScale = 0;
            Canvas.SetActive(false);
            commander.SetActive(false);

            //menu appear
            playAgain.SetActive(true);
            quitGame.SetActive(true);

            if (Season.instance.year == 3)
            {
                winner.SetActive(true);
            }
            else if (town.gameOver)
            {
                loser.SetActive(true);
            }

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

