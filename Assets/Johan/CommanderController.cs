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

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetMouseButtonDown(0) && hover_state == HoverState.HOVER && Resource.instance.total >= 40)
        {
            if (!MapController.instance.plantDictionary.ContainsKey(tilePointer))
            {
                Plant p = (Plant)Instantiate(plants[selectedPlant], MapController.instance.grid.GetCellCenterWorld(tilePointer), Quaternion.identity);
                MapController.instance.plantDictionary.Add(tilePointer, p);
                //other script calls
                Resource.instance.Spend(40);
            }
        }
        //if right click button press
        else if(Input.GetMouseButton(1) && hover_state == HoverState.HOVER)
        {
            if (MapController.instance.plantDictionary.ContainsKey(tilePointer))
            {
                MapController.instance.plantDictionary[tilePointer].Die();
                MapController.instance.plantDictionary.Remove(tilePointer);
            }
        }

    }
}
public enum HoverState
{
    NONE,
    HOVER
}