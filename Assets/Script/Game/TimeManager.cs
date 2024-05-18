using System;
using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    [SerializeField] private int _playTime;
    Coroutine timecounter;
    public Action<int> ActionChangeTime;
    public void InitTime(int timelimit)
    {
        _playTime = timelimit;
        if(timecounter!=null) StopCoroutine(timecounter);
        timecounter = StartCoroutine(TimeCounter());
    }
    
    IEnumerator TimeCounter()
    {
        while (_playTime >0)
        {
            _playTime -= GameManager.Instance.IsPause ? 0 : 1;
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
