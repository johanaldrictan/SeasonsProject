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
        this.transform.Translate(Vector3.left * WalkSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
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
    public int GetDmg()
    {
        return Damage;
    }
}
