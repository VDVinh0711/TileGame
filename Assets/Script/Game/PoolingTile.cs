using System.Collections.Generic;
using UnityEngine;

public class PoolingTile : Singleton<PoolingTile>
{
   [SerializeField] private Transform _hoder;
   public Dictionary<string, Queue<Transform>> poolDictionary = new ();

   private void Awake()
   {
      poolDictionary = new Dictionary<string, Queue<Transform>>();
   }

   public void DeSpawnObj(Transform transform)
   {
      transform.gameObject.SetActive(false);
      transform.SetParent(_hoder);
      if (poolDictionary.ContainsKey(transform.name))
      {
         poolDictionary[transform.name].Enqueue(transform);
         return;
      }
      Queue<Transform> pools = new Queue<Transform>();
      pools.Enqueue(transform);
      poolDictionary.Add(transform.name,pools);
 
   }

   public Transform SpawnObj(Transform objSpawn )
   {
       if (!poolDictionary.ContainsKey(objSpawn.name) || poolDictionary[objSpawn.name].Count == 0 )   return  Instantiate(objSpawn,Vector3.zero, Quaternion.identity);
       var objreturn = poolDictionary[objSpawn.name].Dequeue();
       objreturn.gameObject.transform.position = Vector3.zero;
       objreturn.gameObject.SetActive(true);
       return objreturn;
   }
}
