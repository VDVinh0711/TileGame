using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    const int _containLimit = 6;
    public Stack<Tile> _historyTileClicks = new();
    [SerializeField] private TilePicker _tilePicker;
    public TilePicker TilePicker => _tilePicker;
    
    
    public void ReBackSelectedTile()
    {
        if(_historyTileClicks.Count == 0 ) return;
        var tileUndo = _historyTileClicks.Pop();
        if(tileUndo == null) return;
        _tilePicker.RemovetoContainer(tileUndo);
    }
    public void CheckWin()
    {
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

    public void Reset()
    {
        _historyTileClicks.Clear();
        _tilePicker.Reset();
    }
}
