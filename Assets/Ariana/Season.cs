using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Season : MonoBehaviour
{
    public static Season instance;
    // Start is called before the first frame update
    public string season;
    private AudioSource seasonChimeSource;
    public AudioClip[] seasonChimes;
    public AudioClip[] seasonSongs;
    public float time;

    public float countdown;
    public int seasonNo; //must be number 0-3, 0 = Spring, 1 = Summer, etc.

    public float seasonLen;
    public string[] seasons;

    public int year;
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
       
        time = 0;

        seasonChimeSource = this.GetComponent<AudioSource>();
        this.seasonChimeSource.clip = this.seasonChimes[this.seasonNo];
        seasonChimeSource.Play();

        year = 1;
    }

    // Update is called once per frame
    void Update() //when the timer exceeds or gets to the season length, it cycles
                  //out the season
    {
        time += Time.deltaTime;
        //UnityEngine.Debug.Log(timer.Elapsed);
        if (time >= this.seasonLen)
        {
            //UnityEngine.Debug.Log("changed seasons");
            
            time = 0;
            this.nextSeason();
            countdown = seasonLen;
        }
        countdown = seasonLen - time;
        if (seasonChimeSource.isPlaying == false)
        {
            seasonChimeSource.clip = seasonSongs[this.seasonNo];
            seasonChimeSource.Play();
        }
        //UnityEngine.Debug.Log(this.season);
    }

    void nextSeason() //cycles to the next season
    {
        if (this.seasonNo == 3)
        {
            this.seasonNo = 0;
            year++;
            UnityEngine.Debug.Log("Year " + year);
        }
        else
            ++this.seasonNo;
        this.season = this.seasons[this.seasonNo];
        MapController.instance.ChangeSeason();
        EnemySpawner.instance.healthBonusSeason++;
        seasonChimeSource.clip = seasonChimes[this.seasonNo];
        seasonChimeSource.Play();
        //UnityEngine.Debug.Log(season);
    }
}