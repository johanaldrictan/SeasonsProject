using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 3;
    [SerializeField] private float Damage = 1;
    [SerializeField] private float WalkSpeed = 2;
    [SerializeField] private float force = 800;


    public Plant plant;

    void Update()
    {
        //move position of enemy based on WalkSpeed
        Move();
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Move()
    {
        //this.transform.Translate(Vector3.left * WalkSpeed * Time.deltaTime);
        this.GetComponent<Rigidbody2D>().velocity = Vector2.left * WalkSpeed;
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
}
