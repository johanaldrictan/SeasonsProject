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

    // Update is called once per frame
    void Update()
    {
        //Start Tile highlighting code
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction, 100f);
        if (hit)
        {
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
        if (Input.GetMouseButtonDown(0))
        {
            //SpawnPlant(tilePointer, plant)
        }
    }
}
public enum HoverState
{
    NONE,
    HOVER
}