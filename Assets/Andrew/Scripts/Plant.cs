using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject pelletPrefab;

    private Collider2D plantCollider;
    private Rigidbody2D plantRigidbody;

    private int Health = 10;            //has 10 health
    private int Damage = 1;             //does 1 damage per pellet
    private float TimeToLive = 60f;     //lives for 60 seconds

    private float shootTickValue = 0f;  //value for tracking time between shots
    private float shootTickRate = 1f;

    void Start()
    {
        plantRigidbody = GetComponent<Rigidbody2D>();
        plantCollider = GetComponent<Collider2D>();

    }

    void Update()
    {
        TimeToLive -= Time.deltaTime;
        shootTickValue += Time.deltaTime;

        if (shootTickValue > shootTickRate)
        {
            Shoot();
            shootTickValue = 0f;
        }
    }

    void Shoot()
    {
        GameObject pellet = Instantiate(pelletPrefab, this.transform.position, Quaternion.identity);
        pellet.GetComponent<Rigidbody2D>().velocity = Vector2.down * 7;
        Physics2D.IgnoreCollision(plantCollider, pellet.GetComponent<Collider2D>());
    
    }
}
