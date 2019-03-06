using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject pelletPrefab;

    private Collider2D plantCollider;
    private Rigidbody2D plantRigidbody;

    public int Health = 1;            //has 10 health
    public int Damage = 1;             //does 1 damage per pellet
    private float Timer = 0f;

    private float shootTickValue = 0f;  //value for tracking time between shots
    public float shootTickRate;         //if 0 won't shoot

    //changes per plant prefab
    public int[] saleValue;     //how much it is worth at each stage when removed
    public float[] ripeTime;    //the time intervals where the above sale values are applied
                                //ex: saleValue:      0      80      40
                                //    ripeTime:  (0)     30      45      70 (last digit used for TTL)
                                //             implied

    public int[] GoodSeasons;
    public int CostPrice;
    public bool isResourcePlant;
    private AudioSource shootSoundSource;
    void Start()
    {
        //raycast in all possible directions to find where the town is.
        RaycastHit2D leftHit = Physics2D.Raycast(this.transform.position, Vector2.left);
        RaycastHit2D rightHit = Physics2D.Raycast(this.transform.position, Vector2.right);
        //left Hit
        if (leftHit.collider != null)
        {
            this.transform.Rotate(new Vector3(0, 0, -90));
        }
        else if(rightHit.collider != null)
        {
            this.transform.Rotate(new Vector3(0, 0, 90));
        }

        plantRigidbody = GetComponent<Rigidbody2D>();
        plantCollider = GetComponent<Collider2D>();

        if (saleValue.Length == 0) //default
        {
            saleValue = new int[] { 0 };
        }
        if (CostPrice == 0)
        {
            CostPrice = 40;
        }
        if (ripeTime.Length < 1)
        {
            Debug.Log("ERROR: NO RIPE TIME VALUES SET, NO DEATH VALUE SET");
            Application.Quit();
        }
        shootSoundSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Timer >= ripeTime[ripeTime.Length - 1] || Health <= 0) //last index of ripeTime, the TTL
        {
            //Destroy or something related to removing it, maybe animation idk
            Die();
        }

        if (CheckGoodSeason()) //if it is a good season for the plant normal decay
        {
            Timer += Time.deltaTime;
        }
        else //sped up decay rate
        {
            Timer = Timer + (3 * Time.deltaTime);
        }

        if (shootTickRate != 0f)
            shootTickValue += Time.deltaTime; //timer only increases if tickrate > 0 (meaning a plant that is supposed to shoot)

        if (shootTickValue > shootTickRate && !isResourcePlant)
        {
            Shoot();
            shootTickValue = 0f;
        }
    }

    void Shoot()
    {
        GameObject pellet = Instantiate(pelletPrefab, this.transform.position, this.transform.rotation);
        pellet.transform.position = this.transform.position;
        Physics2D.IgnoreCollision(plantCollider, pellet.GetComponent<Collider2D>());
        pellet.GetComponent<Rigidbody2D>().velocity = transform.up * 5;
        shootSoundSource.Play();
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

    bool CheckGoodSeason()
    {
        for (int i = 0; i < GoodSeasons.Length; i++)
        {
            if (GoodSeasons[i] == Season.instance.seasonNo)
                return true;
        }
        return false;
    }

    public int GetSalePrice()
    {
        int currentSalePrice = 0;
        for (int i = ripeTime.Length - 1; i > -1; i--)
        {
            if (Timer < ripeTime[i])
            {
                currentSalePrice = saleValue[i]; //sets price to right-most value
            }
        }

        if (CheckGoodSeason())
            return currentSalePrice;
        return currentSalePrice / 2;
    }
    //ex: saleValue:      0      80      40
    //    ripeTime:  (0)     30      45      70 (last digit used for TTL)
    //             implied
}
