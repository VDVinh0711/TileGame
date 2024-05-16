using System.Collections.Generic;
using System.Linq;
using TreeEditor;
using UnityEngine;

public class PoolingTile : Singleton<PoolingTile>
{
   [SerializeField] private Transform _hoder;
   [SerializeField] private List<Transform> _container;
   [SerializeField] private Transform _objPrefabs;


   public void DeSpawnObj(Transform transform)
   {
      transform.gameObject.SetActive(false);
      transform.SetParent(_hoder);
      _container.Add(transform);
   }

   public Transform SpawnObj(string name)
   {
      var obj = _container.FirstOrDefault(x => x.name.Contains(name));
      if (obj!=null)
      {
         _container.Remove(obj);
         return obj;
      }

      var spawnNew = Instantiate(_objPrefabs);
      return spawnNew;
   }
}
