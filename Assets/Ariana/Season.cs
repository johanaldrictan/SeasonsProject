﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Season : MonoBehaviour
{
    public static Season instance;
    // Start is called before the first frame update
    public string season;

    public Stopwatch timer;
    public float countdown;
    public int seasonNo; //must be number 0-3, 0 = Spring, 1 = Summer, etc.

    public float seasonLen;
    public string[] seasons;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start() //sets the season, starts the stopwatch
    {
        seasons = new string[4] { "Spring", "Summer", "Fall", "Winter"};
        this.season = this.seasons[this.seasonNo];
        this.timer = new Stopwatch();
        timer.Start();
    }

    // Update is called once per frame
    void Update() //when the timer exceeds or gets to the season length, it cycles
                  //out the season
    {
        //UnityEngine.Debug.Log(timer.Elapsed);
        if (timer.Elapsed.Seconds >= this.seasonLen)
        {
            //UnityEngine.Debug.Log("changed seasons");
            timer.Reset();
            this.nextSeason();
            timer.Start();
            countdown = seasonLen;
        }
        countdown = seasonLen - timer.Elapsed.Seconds;
        
        //UnityEngine.Debug.Log(this.season);
    }

    void nextSeason() //cycles to the next season
    {
        if (this.seasonNo==3)
            this.seasonNo = 0;
        else
            ++this.seasonNo;
        this.season = this.seasons[this.seasonNo];
        //UnityEngine.Debug.Log(season);
    }
}