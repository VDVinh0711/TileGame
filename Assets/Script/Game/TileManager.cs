using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    const int _containLimit = 6;
    public Stack<Tile> historyTileClicks = new();
    [SerializeField] private TilePicker _tilePicker;
    public TilePicker TilePicker => _tilePicker;
    
    
    public void ReBackSelectedTile()
    {
        if(historyTileClicks.Count == 0 ) return;
        var tileUndo = historyTileClicks.Pop();
        if(tileUndo == null) return;
        _tilePicker.RemovetoContainer(tileUndo);
    }
    public void CheckWin()
    {
        ClearHistoryTile();
        if (_tilePicker.QuantityPick != LevelManager.Instance.GetTotalTileInLevel()) return;
        _tilePicker.CanPick = false;
        GameManager.Instance.Win();
    }

    public void CheckLose()
    {
        if (_tilePicker.QuantityContain == _containLimit)
        {
            _tilePicker.CanPick = false;
            GameManager.Instance.Lose();
        }
    }

    public void ClearHistoryTile()
    {
        historyTileClicks.Clear();
    }

    public void Reset()
    {
        historyTileClicks.Clear();
        _tilePicker.Reset();
    }
}
