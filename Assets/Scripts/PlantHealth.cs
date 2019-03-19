using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHealth : MonoBehaviour
{
    private float initalHealth;
    private float currentHealth;
    private int lastHealthTick; //0 indexed

    private GameObject[] healthReference;

    /*private float testTimer;
    private float timeMax;
    private int index;

    void Start()
    {
        testTimer = 0f;
        timeMax = 3f;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        testTimer += Time.deltaTime;
        if (testTimer >= timeMax)
        {
            this.transform.GetChild(index).gameObject.SetActive(false);
            index++;
            testTimer = 0f;
        }
    }*/

    void Start()
    {
        initalHealth = this.gameObject.GetComponentInParent<Plant>().Health;
        currentHealth = initalHealth;
        lastHealthTick = 19;

        healthReference = new GameObject[20];
        for (int i = 0; i < 20; i++)
        {
            healthReference[i] = this.transform.GetChild(i).gameObject;
        }

        //Debug.Log("Health = " + initalHealth);
    }

    public void DecreaseHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        //Debug.Log("Current Health = " + currentHealth + "\nInitial Health = " + initalHealth);

        //Debug.Log("Health percent = " + currentHealth / initalHealth * 20);
        int percent = (int)Mathf.Ceil(currentHealth / initalHealth * 20);

        for (int i = lastHealthTick; i >= percent && i > 0; i--)
        {
            healthReference[i].SetActive(false);
            lastHealthTick--;
        }
    }
}
