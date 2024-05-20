
using System;
using UI_Game;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private bool _isWin = false;
    [SerializeField] private bool _isLose = false;
    [SerializeField] private bool _isPause = false;
    public UnityEvent OnWin;
    public UnityEvent OnLose;
    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private TilePicker _tilePicker;
    public TimeManager TimeManager => _timeManager;
    public bool IsWin => _isWin;
    public bool IsLose => _isLose;
    public bool IsPause => _isPause;
    
    
    public void Win()
    {
        OnWin?.Invoke();
        _isWin = true;
        _tilePicker.CanPick = false;
        var star = CaculatorStar();
        LevelManager.Instance.SaveDataLevel(star);
        UI_Manager.Instance.OpenUiMenuInGame();
        
    }
    public void Lose()
    {
        OnLose?.Invoke();
        _isLose = false;
        _tilePicker.CanPick = false;
        UI_Manager.Instance.OpenUiMenuInGame();
    }
    public void Reload()
    {
        Clear();
        LevelManager.Instance.LoadCurrentlevel();
        _tilePicker.Reset();
    }

    public void PlayGame()
    {
        Clear();
        LevelManager.Instance.LoadLastLevelUnLock();
        UI_Manager.Instance.OpenUIInGame();
        _tilePicker.Reset();
    }
    
    public void PauseGame()
    {
        _isPause = true;
        _tilePicker.CanPick = false;
        UI_Manager.Instance.OpenUiMenuInGame();
    }
    public void ResumeGame()
    {
        if(!_isPause) return;
        UI_Manager.Instance.OpenUIInGame();
        _tilePicker.CanPick = true;
        _isPause = false;
    }
    
    public void NextLevel()
    {
        Clear();
        LevelManager.Instance.NextLevel();
        _tilePicker.Reset();
    }
    public void Clear()
    {
        _isPause = false;
        _isLose = false;
        _isWin = false;
        _tilePicker.Reset();
    }

    public int CaculatorStar()
    {
        var partTimeSize = _timeManager.timelimit /3;
        int currrentpart = (int)Mathf.Floor(_timeManager.playtime / partTimeSize);
        return currrentpart+1;
    }
    
}
