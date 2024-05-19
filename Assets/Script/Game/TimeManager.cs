using System;
using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    [SerializeField] private int _playTime;
    [SerializeField] private int _timeLimit;
    Coroutine timecounter;
    public Action<int> ActionChangeTime;

    public int playtime => _playTime;
    public int timelimit => _timeLimit;
    public void InitTime(int timelimit)
    {
        _playTime = timelimit;
        _timeLimit = timelimit;
        if(timecounter!=null) StopCoroutine(timecounter);
        timecounter = StartCoroutine(TimeCounter());
    }
    
    IEnumerator TimeCounter()
    {
        
        while (_playTime >0)
        {
            var gamemanager = GameManager.Instance;
            var partTimeSize = _timeLimit /3;
            int currrentpart = (int)Mathf.Floor(_playTime / partTimeSize);
            print(3-currrentpart-1);
            _playTime -= gamemanager.IsPause || gamemanager.IsWin || gamemanager.IsLose  ? 0 : 1;
            OnActionChangeTime();
            yield return new WaitForSeconds(1);
        }
        GameManager.Instance.Lose();
    }
    
    public void OnActionChangeTime()
    {
        ActionChangeTime?.Invoke(_playTime);
    }
}
