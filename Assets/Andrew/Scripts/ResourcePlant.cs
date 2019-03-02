using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePlant : MonoBehaviour
{
    private Collider2D plantCollider;
    private Rigidbody2D plantRigidbody;

    public int Health = 1;            //has 10 health
    private float TimeToLive = 60f;     //lives for 60 seconds

    //changes per plant prefab
    public int[] saleValue;     //how much it is worth at each stage when removed
    public float[] ripeTime;    //the time intervals where the above sale values are applied
                                //ex: saleValue:    0      80      40
                                //    ripeTime:  0     30      45      70

    private int SeasonPlantedIn;

    void Start()
    {
        plantRigidbody = GetComponent<Rigidbody2D>();
        plantCollider = GetComponent<Collider2D>();

        SeasonPlantedIn = Season.instance.seasonNo;
    }

    void Update()
    {
        if (TimeToLive <= 0f || Health <= 0)
        {
            //Destroy or something related to removing it, maybe animation idk
            Die();
        }

        if (SeasonPlantedIn != Season.instance.seasonNo)
        {
            TimeToLive = TimeToLive - (3 * Time.deltaTime);
        }
        else
        {
            TimeToLive -= Time.deltaTime;
        }

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

    public int GetSalePrice()
    {
        //TimeToLive++;

        return 0;
    }
}
