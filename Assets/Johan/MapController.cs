using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapController : MonoBehaviour
{
    public static MapController instance;
    public Grid grid;
    public Tilemap plantableTiles;

    //lists all of the plants currently in the map. opted for dictionary to make system independent since the planting field will not necessarily be square
    public Dictionary<Vector3Int, Plant> plantDictionary;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        plantDictionary = new Dictionary<Vector3Int, Plant>();
    }
}