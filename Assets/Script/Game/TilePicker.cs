
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class TilePicker : MonoBehaviour
{
    const int _containLimit = 6;
    [SerializeField] private Transform _posConatainTile;
    [SerializeField] private List<Tile> containerTile = new();
    private Sequence MainSequence;
    public Vector3 spacing;
    private GameRule _gameRule;
    private bool _canpick = true;
    private int _quantityPicker = 0;
    public bool CanPick
    {
        get => _canpick;
        set { _canpick = value; }
    }
 

    private void Awake()
    {
        _gameRule = new GameRule();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canpick)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hits;
            if (Physics.Raycast(ray, out hits))
            {
                GameObject objClick  = hits.collider.gameObject;
                if(objClick == null) return;
                var tileClick = objClick.GetComponent<Tile>();
                if(tileClick.StatePosTile == StatePosTile.inholder) return;
                tileClick.UnSetGravity();
                AddToContainer(tileClick);
                MainSequence = DOTween.Sequence();
                MainSequence.Append(Recallculate());
                EndPicker();
             
            }
        }
    }
    private void AddToContainer(Tile tile)
    {
        tile.StatePosTile = StatePosTile.inholder;
        _quantityPicker++;
        bool isExit = containerTile.Exists(x => x.id == tile.id);
        if (isExit)
        {
            int gopos = containerTile.FindLastIndex(x => x.id == tile.id) + 1;
            containerTile.Insert(gopos, tile);
            return;
        }
        containerTile.Add(tile);
    }
    private void EndPicker()
    {
      var  result = _gameRule.Check(containerTile.ToArray(),out string res);
      if (result)
      {
          
          StartCoroutine(DropOutItemInList(res));
          if (_quantityPicker != LevelManager.Instance.GetTotalTileInLevel()) return;
          _canpick = false;
          
           GameManager.Instance.Win();
          return;
      }
      if (containerTile.Count == _containLimit)
      {
          _canpick = false;
          GameManager.Instance.Lose();
      }

      
    }
    IEnumerator DropOutItemInList(string id)
    {
        yield return new WaitForSeconds(0.4f);
        for (int i = 0; i < containerTile.Count; i++)
        {
            if(!containerTile[i].id.Equals(id))continue;
            containerTile[i].gameObject.transform.DOMove(Vector3.down * 5.0f + containerTile[i].gameObject.transform.position * 10.0f, 1f);
            yield return new WaitForSeconds(0.1f);
            PoolingTile.Instance.DeSpawnObj(containerTile[i].transform);
        }
        containerTile.RemoveAll(x => x.id.Equals(id));
        MainSequence.Append(Recallculate());
        
    }
    public Sequence Recallculate()
    {
        Sequence sequence = DOTween.Sequence();
        for (int i = 0; i < containerTile.Count; i++)
        {
            containerTile[i].transform.DORotate(Vector3.zero, 0.4f);
            sequence.Join(containerTile[i].transform.DOMove(_posConatainTile.position + spacing * i, 0.2f));
        }
        return sequence;

    }

    public void Reset()
    {
        _quantityPicker = 0;
        _canpick = true;
        containerTile.Clear();
    }

}
