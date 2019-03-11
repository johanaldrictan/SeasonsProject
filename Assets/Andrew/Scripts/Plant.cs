﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    public GameObject pelletPrefab;

    private Collider2D plantCollider;
    private Rigidbody2D plantRigidbody;

    public GameObject shotSpawn;

    public int Health = 1;              //has 10 health
    private int initialHealthRef;       //no use other than for an if statement
    public int Damage = 1;              //does 1 damage per pellet
    private float Timer = 0f;

    private float shootTickValue = 0f;  //value for tracking time between shots
    public float shootTickRate;         //if 0 won't shoot

    //changes per plant prefab
    public int[] saleValue;     //how much it is worth at each stage when removed
    public float[] ripeTime;    //the time intervals where the above sale values are applied
                                //ex: saleValue:      0      80      40
                                //    ripeTime:  (0)     30      45      70 (last digit used for TTL)
                                //             implied
    private int currentImageNo = 0; 
    public int[] GoodSeasons;
    public int CostPrice;
    public bool isResourcePlant;
    private AudioSource shootSoundSource;

    public Sprite[] ThisPlantSpriteArray;

    void Start()
    {
        initialHealthRef = Health;

        //raycast in all possible directions to find where the town is.
        RaycastHit2D leftHit = Physics2D.Raycast(this.transform.position, Vector2.left);
        RaycastHit2D rightHit = Physics2D.Raycast(this.transform.position, Vector2.right);
        //left Hit
        if (leftHit.collider != null)
        {
            shotSpawn.transform.Rotate(new Vector3(0, 0, -90));
        }
        else if(rightHit.collider != null)
        {
            shotSpawn.transform.Rotate(new Vector3(0, 0, 90));
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
        /*if (Timer >= ripeTime[ripeTime.Length - 1] || Health <= 0) //last index of ripeTime, the TTL
        {
            //Destroy or something related to removing it, maybe animation idk
            Die();
        }*/

        if (CheckGoodSeason()) //if it is a good season for the plant, normal growth rate
        {
            Timer += Time.deltaTime;
            shootTickRate = .6f;
        }
        else //slow growth rate out of season
        {
            Timer = Timer + (Time.deltaTime / 2);
            shootTickRate = 1.1f;
        }

        if (shootTickRate != 0f)
            shootTickValue += Time.deltaTime; //timer only increases if tickrate > 0 (meaning a plant that is supposed to shoot)

        if (shootTickValue > shootTickRate && !isResourcePlant)
        {
            StartCoroutine(Shoot());
            shootTickValue = 0f;
        }

        GrowPlant();
    }

    IEnumerator Shoot()
    {
        if (CheckGoodSeason() && Season.instance.seasonNo == 0)
        {
            //Debug.Log("Spring plant shoot");
            GameObject pellet = Instantiate(pelletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
            pellet.transform.position = shotSpawn.transform.position;
            pellet.GetComponent<Bullet>().SetDamage(2);
            Physics2D.IgnoreCollision(plantCollider, pellet.GetComponent<Collider2D>());
            shootSoundSource.Play();
        }
        else if (CheckGoodSeason() && Season.instance.seasonNo == 1)
        {
            //Debug.Log("Summer plant shoot");
            GameObject pellet = Instantiate(pelletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
            pellet.transform.position = shotSpawn.transform.position;
            pellet.GetComponent<Bullet>().SetDamage(1);
            Physics2D.IgnoreCollision(plantCollider, pellet.GetComponent<Collider2D>());
            pellet.transform.Rotate(new Vector3(0, 0, 15));

            GameObject pellet1 = Instantiate(pelletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
            pellet1.transform.position = shotSpawn.transform.position;
            pellet1.GetComponent<Bullet>().SetDamage(1);
            Physics2D.IgnoreCollision(plantCollider, pellet1.GetComponent<Collider2D>());

            GameObject pellet2 = Instantiate(pelletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
            pellet2.transform.position = shotSpawn.transform.position;
            pellet2.GetComponent<Bullet>().SetDamage(1);
            Physics2D.IgnoreCollision(plantCollider, pellet2.GetComponent<Collider2D>());
            pellet2.transform.Rotate(new Vector3(0, 0, -15));

            shootSoundSource.Play();
        }
        else if (CheckGoodSeason() && Season.instance.seasonNo == 2)
        {
            //Debug.Log("Fall plant shoot");
            GameObject pellet = Instantiate(pelletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
            pellet.transform.position = shotSpawn.transform.position;
            pellet.GetComponent<Bullet>().SetDamage(1);
            Physics2D.IgnoreCollision(plantCollider, pellet.GetComponent<Collider2D>());
            shootSoundSource.Play();
            yield return new WaitForSeconds(1f);
            GameObject pellet1 = Instantiate(pelletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
            pellet1.transform.position = shotSpawn.transform.position;
            pellet1.GetComponent<Bullet>().SetDamage(1);
            Physics2D.IgnoreCollision(plantCollider, pellet1.GetComponent<Collider2D>());
            shootSoundSource.Play();
        }
        else if (CheckGoodSeason() && Season.instance.seasonNo == 3)
        {
            //Debug.Log("Winter plant shoot");
            GameObject pellet = Instantiate(pelletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
            pellet.transform.position = shotSpawn.transform.position;
            pellet.GetComponent<Bullet>().SetDamage(1);
            pellet.GetComponent<Bullet>().SetSeasonAttribute(3);
            Physics2D.IgnoreCollision(plantCollider, pellet.GetComponent<Collider2D>());
            shootSoundSource.Play();
        }
        else
        {
            //Debug.Log("Base plant shoot");
            GameObject pellet = Instantiate(pelletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
            pellet.transform.position = shotSpawn.transform.position;
            pellet.GetComponent<Bullet>().SetDamage(1);
            Physics2D.IgnoreCollision(plantCollider, pellet.GetComponent<Collider2D>());
            shootSoundSource.Play();
        }
        yield return null;

        /*GameObject pellet = Instantiate(pelletPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation);
        pellet.transform.position = shotSpawn.transform.position;
        pellet.GetComponent<Bullet>().SetDamage(2);
        Physics2D.IgnoreCollision(plantCollider, pellet.GetComponent<Collider2D>());
        pellet.GetComponent<Rigidbody2D>().velocity = shotSpawn.transform.up * 5;
        shootSoundSource.Play();*/
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
            if (initialHealthRef > 1)
                this.transform.GetComponentInChildren<PlantHealth>().DecreaseHealth(1);
            Debug.Log(Health);
            if (Health <= 0)
            {
                Die();
            }
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

        return (Season.instance.seasonNo == 3) ? 0 : currentSalePrice;
    }
    //ex: saleValue:      0      80      40
    //    ripeTime:  (0)     30      45      70 (last digit used for TTL)
    //             implied
    void GrowPlant()
    {
        int savednum = this.currentImageNo;
        for (int i = ripeTime.Length - 1; i > -1; i--)
        {
            if (Timer < ripeTime[i])
            {
                currentImageNo = i;
            }
        }
        if (savednum!=currentImageNo)
        {
            this.GetComponent<SpriteRenderer>().sprite = ThisPlantSpriteArray[currentImageNo];
        }
    }
}
