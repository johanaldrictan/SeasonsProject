using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject pelletPrefab;

    private Collider2D plantCollider;
    private Rigidbody2D plantRigidbody;

    public int Health = 1;            //has 10 health
    private int Damage = 1;             //does 1 damage per pellet
    private float TimeToLive = 60f;     //lives for 60 seconds

    private float shootTickValue = 0f;  //value for tracking time between shots
    private float shootTickRate = 1.25f;
    public Enemy bug;

    private int SeasonPlantedIn;

    void Start()
    {
        plantRigidbody = GetComponent<Rigidbody2D>();
        plantCollider = GetComponent<Collider2D>();

        SeasonPlantedIn = Season.instance.seasonNo;
    }

    void Update()
    {
        shootTickValue += Time.deltaTime;

        if (SeasonPlantedIn != Season.instance.seasonNo)
        {
            TimeToLive = TimeToLive - (3 * Time.deltaTime);
        }
        else
        {
            TimeToLive -= Time.deltaTime;
        }

        if (shootTickValue > shootTickRate)
        {
            Shoot();
            shootTickValue = 0f;
        }

        if (TimeToLive < 0f || Health <= 0)
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
        pellet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 5;
    
    }
    public void Die()
    {
        MapController.instance.plantDictionary.Remove(MapController.instance.grid.WorldToCell(this.transform.position));
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            //Health = Health - bug.GetDmg();
            Health--;
            Debug.Log(Health);
        }
    }

    public int GetDmg()
    {
        return Damage;
    }
}
