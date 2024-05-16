
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointLef;
    [SerializeField] private Transform _spawnPointRight;
    [SerializeField] private Transform _tileSpawn;
    [SerializeField] private List<Transform> _objSpawns = new();
    [SerializeField] private Transform _holderSpawn;
    public void Spawn(TileConfig tileConfig)
    {
        StartCoroutine(SpawnDelay(tileConfig));
    }
    IEnumerator SpawnDelay(TileConfig tileConfig)
    {
        var curentposSpawn = _spawnPointLef.position;
        for (int i = 0; i < tileConfig.Quantity; i++)
        {
            curentposSpawn = curentposSpawn == _spawnPointLef.position ? _spawnPointRight.position :_spawnPointLef.position;
            var tileSpawm = PoolingTile.Instance.SpawnObj(_tileSpawn.name);
            tileSpawm.gameObject.transform.position = curentposSpawn;
            tileSpawm.gameObject.transform.SetParent(_holderSpawn);
            SetupSpawn( _tileSpawn, tileConfig);
            tileSpawm.gameObject.SetActive(true);
            _objSpawns.Add(tileSpawm);
            yield return new WaitForSeconds(1f);
        }
    }
    private void SetupSpawn( Transform objSpawn, TileConfig tileConfig)
    {
        var itemtile = objSpawn.GetComponent<Tile>();
        itemtile.SetUpTile(tileConfig.id, tileConfig.Sprite);
    }

    public void Clear()
    {
        foreach (var objSpawn in _objSpawns)
        {
            PoolingTile.Instance.DeSpawnObj(objSpawn);
        }
    }
}
