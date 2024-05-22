using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolingTile : Singleton<PoolingTile>
{
   [SerializeField] private Transform _hoder;
   public Dictionary<string, Queue<Transform>> poolDictionary;
   [SerializeField] private Transform _objPrefabs;


   private void Awake()
   {
      poolDictionary = new Dictionary<string, Queue<Transform>>();
   }

   public void DeSpawnObj(string nameTag , Transform transform)
   {
      transform.gameObject.SetActive(false);
      transform.gameObject.transform.position = Vector3.zero;
      transform.SetParent(_hoder);
      if (poolDictionary.ContainsKey(nameTag))
      {
         poolDictionary[nameTag].Enqueue(transform);
         return;
      }
      Queue<Transform> pools = new Queue<Transform>();
      pools.Enqueue(transform);
      poolDictionary.Add(nameTag,pools);
 
   }

   public Transform SpawnObj(string nameTag ,Transform objSpawn)
   {
       if (!poolDictionary.ContainsKey(nameTag) || poolDictionary[nameTag].Count == 0 )   return  Instantiate(objSpawn,Vector3.zero, Quaternion.identity);
       var objreturn = poolDictionary[nameTag].Dequeue();
       objreturn.gameObject.transform.position = Vector3.zero;
       objreturn.gameObject.SetActive(true);
       return objreturn;
   }
}
