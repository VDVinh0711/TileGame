using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private List<LevelConfig> _levels = new();
    [SerializeField] private int _currentLevel;
    [SerializeField] private SpawnTile _spawnTile;
    
    public List<LevelConfig> Levels => _levels;

    private void Awake()
    {
        LoadData();
    }
    
    public int CurrentLevel
    {
        get => _currentLevel;
        set
        {
            _currentLevel = value < 0 ? 0 : value;
        }
    }

    public void LoadLastLevelUnLock()
    {
        for (int i = 0; i < _levels.Count; i++)
        {
            if(_levels[i].IsLock==false) continue;
            _currentLevel = i-1;
            break;
        }
        LoadCurrentlevel();
    }
    public void LoadCurrentlevel()
    {
        _spawnTile.Clear();
        foreach (var itemLevel in _levels[_currentLevel].ItemLevels)
        {
            _spawnTile.Spawn(itemLevel);
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
    
   
     
     private void OnDestroy()
     {
         for(int i=0;i< _levels.Count;i++)
         {
             var levelSave = new DataLevel(i, _levels[i].Star, _levels[i].IsLock);
             LevelData.Instance.levelDatas.Add(levelSave);
         }
         LevelData.Instance.Save();
     }
     
     private void LoadData()
     {
         LevelData.Instance.Load();
         for (int i = 0; i < _levels.Count; i++)
         {
             foreach (var dataLevel in LevelData.Instance.levelDatas)
             {
                 if(i != dataLevel.idlevel) continue;
                 _levels[i].IsLock = dataLevel.isLock;
                 _levels[i].Star = dataLevel.star;
             }
         }
     }
     public void SaveDataLevel(int star)
     {
         int starSave = _levels[_currentLevel].Star > star ? _levels[_currentLevel].Star : star;
         _levels[_currentLevel+1].IsLock = false;
         _levels[_currentLevel].Star = starSave;
     }
}

[Serializable]
public class LevelConfig
{
    public List<TileConfig> ItemLevels = new();
    public int Timelimit;
    public bool IsLock = true;
    public int Star = 0;
}

[Serializable]
public class TileConfig
{
    public string id;
    public Sprite Sprite;
    public int Quantity;
}