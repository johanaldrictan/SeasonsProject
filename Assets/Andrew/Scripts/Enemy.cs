using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 3;
    [SerializeField] private float Damage = 1;
    [SerializeField] private float WalkSpeed = 2;
    [SerializeField] private float force = 1200;

    private float slowedSpeed;

    private float slowTimer;


    public Plant plant;

    void Start()
    {
        slowTimer = 0f;
        slowedSpeed = WalkSpeed / 2;
        this.Health += EnemySpawner.instance.getCurrHealthBonus();
    }

    void Update()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
        if (slowTimer > 0)
        {
            slowTimer -= Time.deltaTime;
            MoveSlowed();
        }
        else
        {
            Move();
        }

        //move position of enemy based on WalkSpeed
        //Move();
    }

    void Move()
    {
        //this.transform.Translate(Vector3.left * WalkSpeed * Time.deltaTime);
        this.GetComponent<Rigidbody2D>().velocity = Vector2.left * WalkSpeed;
    }
    void MoveSlowed()
    {
        //this.transform.Translate(Vector3.left * WalkSpeed * Time.deltaTime);
        this.GetComponent<Rigidbody2D>().velocity = Vector2.left * slowedSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("town"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("plant") && collision.gameObject.GetComponent<Plant>().isResourcePlant == false)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector3.right * force); // bug gets pushed back after hitting plant
        }
    }

    public float GetDmg()
    {
        return Damage;
    }
    public void SetSlow()
    {
        slowTimer = 3f;
    }
}
