using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Resource : MonoBehaviour
{
    public int total;
    public int netTotal;

    private int rateResource = 5;
    private float rateSeconds = 2f;

    Stopwatch timer;

    public static Resource instance;
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

    void Start()
    {
        timer = new Stopwatch();
        timer.Start();

        total = 200;
        netTotal = total;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Elapsed.Seconds>=rateSeconds)
        {
            timer.Reset();
            total += rateResource;
            netTotal += rateResource;
            timer.Start();
        }
    }

    public void Spend(int amount)
    {
        total -= amount;
    }

    public void Sell(int amount)
    {
        total += amount;
        netTotal += amount;
    }
}
