using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private int Health = 5;
    [SerializeField]private int Damage = 1;
    [SerializeField] private int WalkSpeed = 1;

    public Plant plant;

    void Update()
    {
        //move position of enemy based on WalkSpeed
        Move();
    }

    void Move()
    {
        this.transform.Translate(new Vector2(0, WalkSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
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
