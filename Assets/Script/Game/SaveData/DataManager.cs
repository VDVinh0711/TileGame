
using UnityEngine;
namespace GameData
{
    public class DataManager 
    {
        public static void SaveData(string key, string data = "")
        {
            PlayerPrefs.DeleteKey(key);
            PlayerPrefs.Save();
            PlayerPrefs.SetString(key,data);
            PlayerPrefs.Save();
        }

        public static string LoadData(string key)
        {
            string result = string.Empty;
            result = PlayerPrefs.GetString(key, string.Empty);
            return result;
        }
    }

}
