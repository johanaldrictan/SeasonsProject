using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPlant;

    public static EnemySpawner instance { get; private set; }

    private float Timer;
    private int SpawnPos;

    void Awake()
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

    private int[,] SpawnLocations = { { 0, 0 }, { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 } };

    void Start()
    {
        Timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //MapController.instance.grid.CellToWorld()
        Timer += Time.deltaTime;
        if (Timer >= 5f)
        {
            SpawnPos = Random.Range(0, 5);
            
            if (SpawnPos == 0)
            {
                GameObject newEnemy = Instantiate(enemyPlant, new Vector3(-2, 0, 0), Quaternion.identity);
                newEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 1;
            }
            else if (SpawnPos == 1)
            {
                GameObject newEnemy = Instantiate(enemyPlant, new Vector3(-1, 0, 0), Quaternion.identity);
                newEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 1;
            }
            else if (SpawnPos == 2)
            {
                GameObject newEnemy = Instantiate(enemyPlant, new Vector3(0, 0, 0), Quaternion.identity);
                newEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 1;
            }
            else if (SpawnPos == 3)
            {
                GameObject newEnemy = Instantiate(enemyPlant, new Vector3(1, 0, 0), Quaternion.identity);
                newEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 1;
            }
            else if (SpawnPos == 4)
            {
                GameObject newEnemy = Instantiate(enemyPlant, new Vector3(2, 0, 0), Quaternion.identity);
                newEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 1;
            }

            Timer = 0f;
        }
    }

    /*IEnumerator SpawnEnemy()
    {
        while ()
        yield return new WaitForSeconds((float)10);
    }*/
}
