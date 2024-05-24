
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    [SerializeField] private Transform tilePrefabs;
    [Header("Position Spawn")] 
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minY;
    [SerializeField] private float minimumDistance = 0.5f;
    [SerializeField] private int maxAttempts = 100;
    [SerializeField] private Transform _holder;
    public List<Transform> allTileObj = new();
    public List<Transform> occupiedPositions = new();


  
    
    public void Spawn( TileConfig config)
    {
        for (int i = 0; i < config.Quantity; i++)
        {
            int at = 0;
            bool foundPosition = false;
            while (!foundPosition && at < maxAttempts)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY), 0);
                bool positionOccupied = false;
                foreach (Transform occupiedPosition in occupiedPositions)
                {
                    if (Vector3.Distance(spawnPosition, occupiedPosition.position) < minimumDistance)
                    {
                        positionOccupied = true;
                        break;
                    }
                }
                if (!positionOccupied)
                {
                    Quaternion spawnRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
                    var tileInstance =   PoolingTile.Instance.SpawnObj(tilePrefabs);
                    tileInstance.SetParent(_holder);
                    tileInstance.position = spawnPosition;
                    tileInstance.rotation = spawnRotation;
                    allTileObj.Add(tileInstance);
                    SetUpAdapterTileSpawn(tileInstance, config);
                    //add to map position to prevent intersect
                    occupiedPositions.Add(tileInstance.transform);
                    foundPosition = true;
                }
                at++;
            }
        }
        occupiedPositions.Clear();
    }
    
    private void SetUpAdapterTileSpawn( Transform objSpawn, TileConfig tileConfig)
    {
        var itemtile = objSpawn.GetComponent<Tile>();
        itemtile.SetUpTile(tileConfig.id, tileConfig.Sprite);
        itemtile.StatePosTile = StatePosTile.incontain;
    }


    public void ReSpawnTile(Tile tile)
    {
        tile.gameObject.SetActive(false);
        Vector3 spawnPosition = new Vector3(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY), 0);
        tile.gameObject.transform.position = spawnPosition;
        tile.gameObject.SetActive(true);
    }


    public void RemoveTile(Tile tile)
    {
        PoolingTile.Instance.DeSpawnObj(tile.transform);
        allTileObj?.RemoveAt(0);
    }
    
    public void Clear()
    {
        foreach (var objSpawn in allTileObj)
        {
            PoolingTile.Instance.DeSpawnObj(objSpawn.transform);
        }
        allTileObj.Clear();
    }
}
