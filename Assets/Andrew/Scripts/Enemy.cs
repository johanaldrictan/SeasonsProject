using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 3;
    [SerializeField] private float Damage = 1;
    [SerializeField] private float WalkSpeed = 2;

    public Plant plant;

    void Update()
    {
        //move position of enemy based on WalkSpeed
        Move();
        if (Health == 0)
        {
            Destroy(this.gameObject);

        }
    }

    void Move()
    {
        this.transform.Translate(Vector3.left * WalkSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("town"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("plant"))
        {
            Destroy(this.gameObject);
            //collision.gameObject.GetComponent<Plant>().Health--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("getting hit 2");
        //if (collider.CompareTag("pellet"))
        //{
        //    //got hit, reduce health by plant damage
        //    Health--;
        //    Debug.Log("getting hit");

        //}

        //Destroy(collider.gameObject);
    }
    public float GetDmg()
    {
        return Damage;
    }
}
