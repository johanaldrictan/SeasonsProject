using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lossCanvas;
    void Start()
    {
        lossCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoseGame()
    {
        lossCanvas.SetActive(true);
    }
}
