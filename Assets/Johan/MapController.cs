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
    Dictionary<Vector3Int, Plant> plantDictionary;

    private void Awake()
    {
        //each scene load I want a new instance of the mapcontroller but it needs to stay static
        //needs to load start again in each scene
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        plantDictionary = new Dictionary<Vector3Int, Plant>();
    }
}