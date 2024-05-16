using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private List<LevelConfig> _levels = new();
    [SerializeField] private int _currentLevel;
    [SerializeField] private SpawnTile _spawnTile;
    public int CurrentLevel
    {
        get => _currentLevel;
        set
        {
            _currentLevel = value < 0 ? 0 : value;
        }
    }
    
    
    private void Start()
    {
        LoadCurrentlevel();
    }

    public void LoadCurrentlevel()
    {
        _spawnTile.Clear();
        StartCoroutine(LoadLevelConfig());
    }
     IEnumerator LoadLevelConfig()
     {
        foreach (var itemLevel in _levels[_currentLevel].ItemLevels)
        {
           _spawnTile.Spawn(itemLevel);
            yield return new WaitForSeconds(0.5f);
        }
        GameManager.Instance.TimeManager.InitTime(_levels[_currentLevel].Timelimit);
     }
     public void NextLevel()
     {
         _currentLevel++;
         LoadCurrentlevel();
     }


     public int GetTotalTileInLevel()
     {
         var result = 0;
         foreach (var itemLevel in _levels[_currentLevel].ItemLevels)
         {
             result += itemLevel.Quantity;
         }

         return result;
     }
    
}

[Serializable]
public class LevelConfig
{
    public List<TileConfig> ItemLevels = new();
    public int Timelimit;
}

[Serializable]
public class TileConfig
{
    public string id;
    public Sprite Sprite;
    public int Quantity;
}