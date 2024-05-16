
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public bool IsPause = false;
    public UnityEvent OnWin;
    public UnityEvent OnLose;
    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private TilePicker _tilePicker;
    public TimeManager TimeManager => _timeManager;
    
    
    public void Win()
    {
        print("win");
        OnWin?.Invoke();
        IsPause = true;
        //Call UI Win
    }

    public void Lose()
    {
        print("lose");
        OnLose?.Invoke();
        IsPause = true;
        //Call UI Lose
    }
    
    public void Reload()
    {
        LevelManager.Instance.LoadCurrentlevel();
        _tilePicker.Reset();
        IsPause = true;
        
    }

    public void NextLevel()
    {
        LevelManager.Instance.NextLevel();
        _tilePicker.Reset();
        
    }
    
    public void Clear()
    {
        IsPause = false;
        _tilePicker.Reset();
    }
}
