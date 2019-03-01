using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float Timer;
    private float TimerThreshold;
    private float subTimerThreshold;

    private int currBag = 0;

    private int currResourceCounter; //replace all instances of this with Resource.instance.totalResource
    public int[] resourceLevels;
    private int currLevel;


    //if a bag has no specified size in the inspector, will not be used
    //Bags picks bags based on level
    private List<GameObject[]> Bags;
    public GameObject[] Bag1;
    public GameObject[] Bag2;
    public GameObject[] Bag3;
    public GameObject[] Bag4;
    public GameObject[] Bag5;

    public Vector3[] spawnCoords;


    public static EnemySpawner instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    //private int[,] SpawnLocations = { { 0, 0 }, { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 } };

    void Start()
    {
        Timer = 0f;
        TimerThreshold = 10f;
        subTimerThreshold = 2f;

        if (Bag1.Length > 0)
            Bags.Add(Bag1);
        if (Bag2.Length > 0)
            Bags.Add(Bag2);
        if (Bag3.Length > 0)
            Bags.Add(Bag3);
        if (Bag4.Length > 0)
            Bags.Add(Bag4);
        if (Bag5.Length > 0)
            Bags.Add(Bag5);

        //error check
        if (Bags.Count < 1)
        {
            Debug.Log("ERROR: NO ENEMIES SET");
            Application.Quit();
        }
        if (spawnCoords.Length < 1)
        {
            Debug.Log("ERROR: NO SPAWN COORDINATES SET");
            Application.Quit();
        }
        if ((resourceLevels.Length - 1) != Bags.Count)
        {
            Debug.Log("ERROR: NOT RIGHT COUNT OF BAGS AND RESOURCELEVELS");
            Application.Quit();
        }
    }

    void Update()
    {
        if (currResourceCounter > resourceLevels[currLevel] && currLevel < (Bags.Count - 1))
        {
            currLevel++;
            currBag++;
        }

        Timer += Time.deltaTime;
        if (Timer >= TimerThreshold)
        {
            StartCoroutine(SpawnBag(Bags[currBag])); //the GameObject[]
            Timer = 0f;
        }
    }

    IEnumerator SpawnBag(GameObject[] Bag)
    {
        int bagIndex = 0;
        float subTimer = 0f;
        ShuffleBag(Bag);
        while (bagIndex < Bag.Length)
        {
            subTimer += Time.deltaTime;
            if (subTimer >= subTimerThreshold)
            {
                GameObject newEnemy = Instantiate(Bag[bagIndex], spawnCoords[Random.Range(0, spawnCoords.Length)], Quaternion.identity);
                newEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 1;

                bagIndex++;
                subTimer = 0f;
            }
        }
        yield return null;
    }

    void ShuffleBag(GameObject[] Bag)
    {
        int r;
        GameObject copy;
        for (int i = 0; i < Bag.Length; i++)
        {
            r = Random.Range(0, Bag.Length);
            copy = Bag[i];
            Bag[i] = Bag[r];
            Bag[r] = copy;
        }
    }


    // Update is called once per frame
    /*void Update()
    {
        //MapController.instance.grid.CellToWorld()
        Timer += Time.deltaTime;
        if (Timer >= 5f)
        {
            SpawnPos = Random.Range(0, 5);
            
            if (SpawnPos == 0)
            {
                GameObject newEnemy = Instantiate(enemyPlant, new Vector3(6, 1.5F, 0), Quaternion.identity);
                newEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 1;
            }
            else if (SpawnPos == 1)
            {
                GameObject newEnemy = Instantiate(enemyPlant, new Vector3(6, .5F, 0), Quaternion.identity);
                newEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 1;
            }
            else if (SpawnPos == 2)
            {
                GameObject newEnemy = Instantiate(enemyPlant, new Vector3(6, -.5F, 0), Quaternion.identity);
                newEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 1;
            }
            else if (SpawnPos == 3)
            {
                GameObject newEnemy = Instantiate(enemyPlant, new Vector3(6, -1.5F, 0), Quaternion.identity);
                newEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 1;
            }
            else if (SpawnPos == 4)
            {
                GameObject newEnemy = Instantiate(enemyPlant, new Vector3(6, -2.5F, 0), Quaternion.identity);
                newEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 1;
            }

            Timer = 0f;
        }
    }*/
}
