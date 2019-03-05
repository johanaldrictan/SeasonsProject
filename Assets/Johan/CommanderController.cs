using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
    public int selectedPlant;

    public AudioClip plantSound;
    public AudioClip harvestSound;
    public AudioClip sellSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        selectedPlant = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //plant selection by q/w/e/r
        PlantSelction();

        //Start Tile highlighting code
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction, 100f);
        if (hit)
        {
            if(hit.collider.CompareTag("PlantableTiles"))
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
            //Debug.Log(MapController.instance.grid.CellToWorld(MapController.instance.grid.WorldToCell(hit.point)));
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
        //if left click button press
        if (Input.GetMouseButtonDown(0) && hover_state == HoverState.HOVER && Resource.instance.total >= plants[selectedPlant].CostPrice)
        {
            if (!MapController.instance.plantDictionary.ContainsKey(tilePointer))
            {
                audioSource.clip = plantSound;
                audioSource.Play();
                Plant p = (Plant)Instantiate(plants[selectedPlant], MapController.instance.grid.GetCellCenterWorld(tilePointer), Quaternion.identity);
                MapController.instance.plantDictionary.Add(tilePointer, p);
                //other script calls
                Resource.instance.Spend(plants[selectedPlant].CostPrice);
            }
        }
        //if right click button press
        else if(Input.GetMouseButton(1) && hover_state == HoverState.HOVER)
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
        if (Input.GetKeyDown(KeyCode.Tab))
            //circular add
            //check if plant is at the end of the list
            selectedPlant = selectedPlant == plants.Length - 1 ? 0 : selectedPlant + 1;
    }

    void PlantSelction()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Debug.Log("Q");
            selectedPlant = 0;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("W");
            selectedPlant = 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("E");
            selectedPlant = 2;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Debug.Log("R");
            selectedPlant = 3;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("A");
            selectedPlant = 4;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Debug.Log("S");
            selectedPlant = 5;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("D");
            selectedPlant = 6;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("F");
            selectedPlant = 7;
        }
    }
}
public enum HoverState
{
    NONE,
    HOVER
}