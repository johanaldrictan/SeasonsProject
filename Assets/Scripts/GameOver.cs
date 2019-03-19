using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject lossCanvas;
    public string GameScene;

    void Start()
    {
        //lossCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoseGame()
    {
        Debug.Log("You Lost");
        SceneManager.LoadScene(GameScene, LoadSceneMode.Single);
    }
}
