﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField]private int Health = 5;
    [SerializeField]private int Damage = 1;
=======
    [SerializeField] private int Health = 5;
    [SerializeField] private int Damage = 1;
>>>>>>> ScriptCombinationTest1
    [SerializeField] private int WalkSpeed = 1;

    public Plant plant;

    void Update()
    {
        //move position of enemy based on WalkSpeed
        Move();
    }

    void Move()
    {
<<<<<<< HEAD
        this.transform.Translate(new Vector2(0, WalkSpeed * Time.deltaTime));
=======
        this.transform.Translate(Vector3.left * WalkSpeed * Time.deltaTime);
>>>>>>> ScriptCombinationTest1
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
<<<<<<< HEAD
        if (collider.tag == "pellet")
        {
            //got hit, reduce health by plant damage
            Health = Health - plant.GetDmg();
            if (Health == 0)
            {
                Destroy(this.gameObject); 
            }
            
        }

        if(collider.tag == "town")
        {
            Destroy(this.gameObject);
        }
    }

    public int GetDmg()
    {
        return Damage;
    }

    
}
=======
        if (collider.CompareTag("pellet"))
        {
            //got hit, reduce health by plant damage
            Health--;
            if (Health == 0)
            {
                Destroy(this.gameObject);
            }

        }

        if (collider.CompareTag("town"))
        {
            Destroy(this.gameObject);
        }
    }
}
>>>>>>> ScriptCombinationTest1
