using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private int Resources;      //tracks resources
    private float Timer;        //internally tracks so it changes the season
    private int CurrentSeason;  //replace with enum?

    public static Game_Manager instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
