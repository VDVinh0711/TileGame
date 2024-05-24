
using System.Collections.Generic;
using GameData;
using UnityEngine;

public class LevelData
{
   private static LevelData _instance;

   public static LevelData Instance
   {
      get
      {
         if (_instance == null)
         {
            _instance = new LevelData();
         }

         return _instance;
      }
   }

   public void Save()
   {
      string data = JsonUtility.ToJson(this);
      DataManager.SaveData("DataLevel",data);
   }

   public void Load()
   {
      string data = DataManager.LoadData("DataLevel");
      if (_instance == null)
      {
         _instance = new LevelData();
      }

      _instance = JsonUtility.FromJson<LevelData>(data);
   }

   public List<DataLevel> levelDatas = new();
}


[System.Serializable]
public class DataLevel
{
   public int idlevel;
   public int star;
   public bool isLock;

   public DataLevel(int ideLevel, int star , bool islock)
   {
      this.idlevel = ideLevel;
      this.star = star;
      this.isLock = islock;
   }
}
