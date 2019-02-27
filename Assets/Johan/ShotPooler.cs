using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPooler : MonoBehaviour
{
    public static ShotPooler instance;
    //This is what we're pooling
    public GameObject shotPrefab;
    //Array that keeps track of what we have in our pool
    public List<GameObject> shots;
    //Number of things we want pooled
    public int amountToPool;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        //Instantiate pool
        shots = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject shot = (GameObject)Instantiate(shotPrefab);
            shot.SetActive(false);
            shots.Add(shot);
        }
    }
    public GameObject GetShot()
    {
        for(int i = 0; i < shots.Count; i++)
        {
            //check if shot is currently not active in the screen
            if (!shots[i].activeInHierarchy)
            {
                return shots[i];
            }
        }
        //Debug.Log("No Shots available");
        //unable to find available shot
        return null;
    }
}
