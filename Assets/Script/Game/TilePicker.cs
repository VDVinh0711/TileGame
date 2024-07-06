
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;


public class TilePicker : MonoBehaviour
{
  
    private GameRule _gameRule;
    private bool _canpick = true;
    private int _quantityPicker = 0;
    private Sequence MainSequence;
    public Vector3 spacing;
  
  
    [SerializeField] private TileManager _tileManager;
    [SerializeField] private Transform _posConatainTile;
    [SerializeField] private List<Tile> containerTile = new();
    [SerializeField] private SpawnTile _spawnTile;
    public int QuantityPick => _quantityPicker;
    public int QuantityContain => containerTile.Count;
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
                if(objClick == null || !objClick.gameObject.CompareTag("Tile")) return;
                var tileClick = objClick.GetComponent<Tile>();
                SoundManager.Instance.PlayAudioSFX(Sound.clickget);
                switch (tileClick.StatePosTile)
                {
                    case StatePosTile.incontain :
                        tileClick.UnSetGravity();
                        AddToContainer(tileClick);
                       _tileManager.historyTileClicks.Push(tileClick);
                        break;
                    case StatePosTile.inholder :
                        RemovetoContainer(tileClick);
                        break;
                }
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
    public void RemovetoContainer(Tile tile)
    {
        if(tile == null) return;
        if(!containerTile.Contains(tile)) return;
        tile.StatePosTile = StatePosTile.incontain;
        _quantityPicker--;
        int gopos = containerTile.FindLastIndex(x => x.id == tile.id);
        containerTile.RemoveAt(gopos);
        _spawnTile.ReSpawnTile(tile);
        MainSequence.Append(Recallculate());
    }
   
    private void EndPicker()
    {
      var  result = _gameRule.Check(containerTile.ToArray(),out string res);
      if (result)
      {
         StartCoroutine(DropOutItemInList(res));
          _tileManager.CheckWin();
          return;
      }
      _tileManager.CheckLose();
    }
    IEnumerator DropOutItemInList(string id)
    {
        _canpick = false;
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < containerTile.Count; i++)
        {
            if(!containerTile[i].id.Equals(id))continue;
            var posOBJ = containerTile[i].gameObject.transform.position;
            yield return new WaitForSeconds(0.1f);
            containerTile[i].gameObject.transform.DOMove(new Vector3(0,posOBJ.y - 50,0), 0.3f * i);
            
        }
        containerTile.RemoveAll(x => x.id.Equals(id));
        MainSequence.Append(Recallculate());
        _canpick = true;

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
