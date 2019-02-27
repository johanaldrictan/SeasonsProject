using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Resource : MonoBehaviour
{
    public static Resource instance;
    public int total;

    public int rateResource; // rateResource / rateSeconds = rate at which 
                             // resources are given to the player

    public int rateSeconds;

    Stopwatch timer;
    // Start is called before the first frame update
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
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        timer = new Stopwatch();
        timer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Elapsed.Seconds>=rateSeconds)
        {
            timer.Reset();
            total+=rateResource;
            timer.Start();
        }
    }

    public void Spend(int amount)
    {
        total -= amount;
    }
}
