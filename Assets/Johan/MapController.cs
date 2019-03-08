using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapController : MonoBehaviour
{
    public static MapController instance;
    public Grid grid;
    public Tilemap plantableTiles;

    public List<Vector3Int> allPlantableLocs;

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
    }
    private void Start()
    {
        plantDictionary = new Dictionary<Vector3Int, Plant>();
        allPlantableLocs = new List<Vector3Int>();
        GetPlantableMap();
    }
    private void GetPlantableMap()
    {
        for (int x = plantableTiles.cellBounds.xMin; x < plantableTiles.cellBounds.xMax; x++)
        {
            for (int y = plantableTiles.cellBounds.yMin; y < plantableTiles.cellBounds.yMax; y++)
            {
                Vector3Int localPlace = (new Vector3Int(x, y, 0));
                if (plantableTiles.HasTile(localPlace))
                {
                    //Tile at "place"
                    allPlantableLocs.Add(localPlace);
                }
            }
        }
    }
}