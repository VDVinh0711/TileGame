
using System;
using UI_Game;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{

     private bool _isWin = false;
     private bool _isLose = false;
     private bool _isPause = false;
    public UnityEvent OnWin;
    public UnityEvent OnLose;
    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private TileManager _tileManager;
    [SerializeField] private SpawnTile _spawnTile;
    public TimeManager TimeManager => _timeManager;
    public bool IsWin => _isWin;
    public bool IsLose => _isLose;
    public bool IsPause => _isPause;
    
    
    public void Win()
    {
        OnWin?.Invoke();
        _isWin = true;
        var star = CaculatorStar();
        LevelManager.Instance.SaveDataLevel(star);
        UI_Manager.Instance.OpenUiMenuInGame();
        
    }
    public void Lose()
    {
        OnLose?.Invoke();
        _isLose = false;
  
        UI_Manager.Instance.OpenUiMenuInGame();
    }
    public void Reload()
    {
        Clear();
        LevelManager.Instance.LoadCurrentlevel();
       
    }

    public void PlayGame()
    {
        Clear();
        LevelManager.Instance.LoadLastLevelUnLock();
        UI_Manager.Instance.OpenUIInGame();
        _tileManager.Reset();
    }
    
    public void PauseGame()
    {
        _isPause = true;
        _tileManager.TilePicker.CanPick = false;
        UI_Manager.Instance.OpenUiMenuInGame();
    }
    public void ResumeGame()
    {
        if(!_isPause) return;
        _tileManager.TilePicker.CanPick = true;
        UI_Manager.Instance.OpenUIInGame();
        _isPause = false;
    }
    
    public void NextLevel()
    {
        Clear();
        LevelManager.Instance.NextLevel();
        _tileManager.Reset();
    }
    public void Clear()
    {
        _isPause = false;
        _isLose = false;
        _isWin = false;
        _tileManager.Reset();
        _spawnTile.Clear();
        
    }

    public int CaculatorStar()
    {
        var partTimeSize = _timeManager.timelimit /3;
        int currrentpart = (int)Mathf.Floor(_timeManager.playtime / partTimeSize);
        return currrentpart+1;
    }
    
}
