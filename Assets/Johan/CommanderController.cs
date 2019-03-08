using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CommanderController : MonoBehaviour
{
    Ray ray;
    RaycastHit2D hit;
    HoverState hover_state;
    Vector3Int lastTileLoc;

    public Vector3Int tilePointer;

    public Tilemap tileSelecting;

    public TileBase tileSelector;

    public Plant[] plants;

    public AudioClip plantSound;
    public AudioClip harvestSound;
    public AudioClip sellSound;

    private AudioSource audioSource;

    public bool resourcePlantToggle;
    public int selectedPlant;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        resourcePlantToggle = false;
        selectedPlant = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            resourcePlantToggle = !resourcePlantToggle;
        }
        selectedPlant = !resourcePlantToggle ? Season.instance.seasonNo : Season.instance.seasonNo + Season.instance.seasons.Length;

        MouseOverTile();
        //HandleArrowKeyInput();

        HandleMouseClick();
        HandleSpacebar();
        
    }
    /*
    public void HandleArrowKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3Int tryMoveTilePointer = tilePointer + new Vector3Int(-1, 0, 0);
            //check if in bounds
            if (MapController.instance.InMapBounds(tryMoveTilePointer))
            {
                tilePointer = tryMoveTilePointer;
            }
            else
            {
                tilePointer = MapController.instance.allPlantableLocs[0];
            }
            hover_state = HoverState.HOVER;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3Int tryMoveTilePointer = tilePointer + new Vector3Int(1, 0, 0);
            //check if in bounds
            if (MapController.instance.InMapBounds(tryMoveTilePointer))
            {
                tilePointer = tryMoveTilePointer;
            }
            else
            {
                tilePointer = MapController.instance.allPlantableLocs[0];
            }
            hover_state = HoverState.HOVER;

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3Int tryMoveTilePointer = tilePointer + new Vector3Int(0, 1, 0);
            //check if in bounds
            if (MapController.instance.InMapBounds(tryMoveTilePointer))
            {
                tilePointer = tryMoveTilePointer;
            }
            else
            {
                tilePointer = MapController.instance.allPlantableLocs[0];
            }
            hover_state = HoverState.HOVER;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3Int tryMoveTilePointer = tilePointer + new Vector3Int(0, -1, 0);
            //check if in bounds
            if (MapController.instance.InMapBounds(tryMoveTilePointer))
            {
                tilePointer = tryMoveTilePointer;
            }
            else
            {
                tilePointer = MapController.instance.allPlantableLocs[0];
            }
            hover_state = HoverState.HOVER;

        }
        if (lastTileLoc != null)
            tileSelecting.SetTile(lastTileLoc, null);
        lastTileLoc = MapController.instance.grid.WorldToCell(tilePointer);
        tileSelecting.SetTile(MapController.instance.grid.WorldToCell(tilePointer), tileSelector);

    }
    */
    public void HandleMouseClick()
    {
        //if left click button press
        if (Input.GetMouseButtonDown(0) && hover_state == HoverState.HOVER && Resource.instance.total >= plants[selectedPlant].CostPrice)
        {
            PlacePlant();
        }
        //if right click button press
        else if (Input.GetMouseButton(1) && hover_state == HoverState.HOVER)
        {
            RemovePlant();
        }
    }

    public void HandleSpacebar()
    {
        //if left click button press
        if (Input.GetKeyDown(KeyCode.Space) && hover_state == HoverState.HOVER && Resource.instance.total >= plants[selectedPlant].CostPrice)
        {
            PlacePlant();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && hover_state == HoverState.HOVER)
        {
            RemovePlant();
        }
    }



    public void RemovePlant()
    {
        if (MapController.instance.plantDictionary.ContainsKey(tilePointer))
        {
            //Debug.Log(MapController.instance.plantDictionary[tilePointer].name);
            if (MapController.instance.plantDictionary[tilePointer].isResourcePlant)
            {
                audioSource.clip = sellSound;
                Resource.instance.Sell(MapController.instance.plantDictionary[tilePointer].GetSalePrice());
            }
            else
            {
                audioSource.clip = harvestSound;
            }
            audioSource.Play();
            MapController.instance.plantDictionary[tilePointer].Die();
            MapController.instance.plantDictionary.Remove(tilePointer);
        }
    }
    public void PlacePlant()
    {
        if (!MapController.instance.plantDictionary.ContainsKey(tilePointer))
        {
            Vector3 raycast = MapController.instance.grid.GetCellCenterWorld(tilePointer);
            raycast = raycast - new Vector3(.5f, 0);
            RaycastHit2D hit = Physics2D.Raycast(raycast, Vector2.right, 3.5f);
            Debug.DrawRay(raycast, Vector2.right, Color.yellow, 100000000);
            if (!hit.collider.CompareTag("Enemy"))
            {
                audioSource.clip = plantSound;
                audioSource.Play();
                Plant p = (Plant)Instantiate(plants[selectedPlant], MapController.instance.grid.GetCellCenterWorld(tilePointer), Quaternion.identity);
                MapController.instance.plantDictionary.Add(tilePointer, p);
                //other script calls
                Resource.instance.Spend(plants[selectedPlant].CostPrice);
            }
        }
    }
    public void MouseOverTile()
    {
        //Start Tile highlighting code
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction, 100f);
        if (hit)
        {
            if (hit.collider.CompareTag("PlantableTiles"))
                hover_state = HoverState.HOVER;
        }
        else
        {
            hover_state = HoverState.NONE;
        }

        if (hover_state == HoverState.HOVER)
        {
            //Mouse is hovering
            //Debug.Log(mapController.GridToMap(mapController.grid.WorldToCell(hit.point)));
            Debug.Log(MapController.instance.grid.CellToWorld(MapController.instance.grid.WorldToCell(hit.point)));
            if (lastTileLoc != null)
                tileSelecting.SetTile(lastTileLoc, null);
            lastTileLoc = MapController.instance.grid.WorldToCell(hit.point);
            tileSelecting.SetTile(MapController.instance.grid.WorldToCell(hit.point), tileSelector);
            tilePointer = MapController.instance.grid.WorldToCell(hit.point);
        }
        else
        {
            tileSelecting.SetTile(lastTileLoc, null);
        }
        //End Tile highlighting code
    }
}
public enum HoverState
{
    NONE,
    HOVER
}