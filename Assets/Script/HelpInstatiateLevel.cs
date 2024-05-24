
using System.Collections.Generic;
using UnityEngine;


public class HelpInstatiateLevel : MonoBehaviour
{
    private const int spaceTime = 30;
    private const int spaceQuantity = 3;
    private const int quantityLevel = 10;
    private Sprite _lastSprite;
    [SerializeField] private List<Sprite> _imagetoLoad = new();
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private string _checkvalidat;
    [SerializeField] private List<Sprite> _historySprite = new();
    private void OnValidate()
    {
       Instantiate();
       
    }

    public void Instantiate()
    {
        _levelManager._levels.Clear();
        var countquantity = 4;
        var time = 60;
        for (int i = 0; i < quantityLevel; i++)
        {
            var tileconfigadd = new List<TileConfig>();
            _historySprite.Clear();
            for (int j = 0; j < countquantity; j++)
            {
                var tileadd = new TileConfig(j.ToString(), GetRandomImage(), 6);
                tileconfigadd.Add(tileadd);
            }

            var islock = i == 0 ? false : true;
            var leveladd = new LevelConfig(tileconfigadd, time, islock, 0);
            _levelManager._levels.Add(leveladd);
            countquantity += spaceQuantity;
            time += spaceTime;

        }
    }


    public Sprite GetRandomImage()
    {
        var spriteget = _imagetoLoad[0];
        while (_historySprite.Contains(spriteget))
        {
            spriteget = _imagetoLoad[Random.Range(0, _imagetoLoad.Count)];
        }
        _historySprite.Add(spriteget);
        return spriteget;
    }
}
