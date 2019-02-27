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
    public Enemy bug;

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

        if (TimeToLive < 0f || Health == 0)
        {
            //Destroy or something related to removing it, maybe animation idk
            Die();
        }
    }

    void Shoot()
    {
        GameObject pellet = Instantiate(pelletPrefab, this.transform.position, this.transform.rotation);
        pellet.transform.position = this.transform.position;
        Physics2D.IgnoreCollision(plantCollider, pellet.GetComponent<Collider2D>());
        pellet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 7;
    
    }
    void Die()
    {
        MapController.instance.plantDictionary.Remove(MapController.instance.grid.WorldToCell(this.transform.position));
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            Health = Health - bug.GetDmg();
        }
    }

    public int GetDmg()
    {
        return Damage;
    }
}
