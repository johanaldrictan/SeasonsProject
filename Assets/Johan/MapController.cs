using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapController : MonoBehaviour
{
    public static MapController instance;
    public Grid grid;
    public Tilemap plantableTiles;

    public Tilemap nonPlantableTiles;
    public Tilemap expansionTiles;

    public Color springColor;
    public Color summerColor;
    public Color fallColor;
    public Color winterColor;

    public List<Vector3Int> allPlantableLocs;
    public List<Vector3Int> tilePointerLocs;

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
        ChangeSeason();
    }
    public void ChangeSeason()
    {
        switch (Season.instance.seasonNo)
        {
            case 0:
                ChangeTileColor(springColor);
                break;
            case 1:
                ChangeTileColor(summerColor);
                break;
            case 2:
                ChangeTileColor(fallColor);
                break;
            case 3:
                ChangeTileColor(winterColor);
                break;
        }
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
        for (int x = expansionTiles.cellBounds.xMin; x < expansionTiles.cellBounds.xMax; x++)
        {
            for (int y = expansionTiles.cellBounds.yMin; y < expansionTiles.cellBounds.yMax; y++)
            {
                Vector3Int localPlace = (new Vector3Int(x, y, 0));
                if (expansionTiles.HasTile(localPlace))
                {
                    //Tile at "place"
                    tilePointerLocs.Add(localPlace);
                }
            }
        }
    }
    private void ChangeTileColor(Color color)
    {
        nonPlantableTiles.color = color;
        expansionTiles.color = color;
    }
    public bool InMapBounds(Vector3Int loc)
    {
        return allPlantableLocs.Contains(loc) || tilePointerLocs.Contains(loc);
    }
    public bool InPlantableBounds(Vector3Int loc) 
    {
        return allPlantableLocs.Contains(loc);
    }
}