using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleTiles : MonoBehaviour
{
    //Make sure you have using UnityEngine.Tilemaps at the top for this script to work
    private Tilemap tilemap;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void DestroyTileAtPosition(RaycastHit2D hit)
    {        
		var cell = GetTileAtPosition(hit);
        //This disables the tile
        tilemap.SetTile(cell, null);       
    }
	
	private Vector3Int GetTileAtPosition(RaycastHit2D hit)
	{
        Vector3 hitPosition = Vector3.zero;
        hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
        hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
        Vector3Int cell = tilemap.WorldToCell(hitPosition);
		return cell;
	}
}