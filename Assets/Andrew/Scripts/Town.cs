﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town : MonoBehaviour
{
    [SerializeField]private int health;
    public Enemy bug;
    private void Start()
    {
        health = 10;
    }

    private void Update()
    {
        if (health == 0)
        {
            Debug.Log("--GAME OVER--");
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            health = health - bug.GetDmg();
            Debug.Log(health);
        }
    }
}
