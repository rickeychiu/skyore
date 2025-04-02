using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject[] mapTiles;
    public Transform tileStorage;
    public float offsetx;
    public float startoffsetx;
    public float miny, maxy;
    public float spawnPos;
    public float spawnFreq;
    // Start is called before the first frame update
    public void BeginGame()
    {
        SpawnMapPiece(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( (transform.position.x - spawnPos) >= spawnFreq) {
            SpawnMapPiece(false);    
        }
    }

    public void SpawnMapPiece(bool starting) {

        spawnPos = transform.position.x;
        GameObject tile = mapTiles[Random.Range(0, mapTiles.Length)];
        GameObject spawnedTile = Instantiate(tile) as GameObject;
        spawnedTile.transform.SetParent(tileStorage);
        spawnedTile.transform.position = new Vector3 (transform.position.x + offsetx, Random.Range(miny, maxy), 0);
        if (starting) 
        {
            spawnedTile.transform.position = new Vector3 (transform.position.x + startoffsetx, Random.Range(miny, maxy), 0);
        }
    }
}
