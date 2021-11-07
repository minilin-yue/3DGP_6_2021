using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class SaveData : MonoBehaviour
{
    
    [System.Serializable]
    public class itemData
    {
        public string name;
        public Vector3 pos;
        public Quaternion rot;
        public bool isActive;
    }
    //[System.Serializable]
    //public class gameState
    //{
    //    public GameManager.Chapter chapter = GameManager.Chapter.unStart;
    //    public List<itemData> items = new List<itemData>();
    //}
    //[System.Serializable]
    //public class bagState
    //{
    //    public List<Item> itemList = new List<Item>();
    //}
    [System.Serializable]
    public class memoryState
    {
        public GM_memoryDoor.Chapter chapter = GM_memoryDoor.Chapter.unStart;
    }
    
    public static void Save<T>(T data, string fileName)
    {
        var serializedData = JsonUtility.ToJson(data);
        var byteData = Encoding.UTF8.GetBytes(serializedData);
        var filePath = Application.persistentDataPath + "/" + fileName;
        File.WriteAllBytes(filePath, byteData);
    }

    public static T Load<T>(string fileName)
    {
        var filePath = Application.persistentDataPath + "/" + fileName;
        var serializedData = (byte[])(null);
       try
        {
            serializedData = File.ReadAllBytes(filePath);
            Debug.Log("FileFound");
        }
        catch (System.IO.FileNotFoundException)
        {
            T n = default(T);
            Debug.Log("FileNotFoundException");
            return n;
        }
        return JsonUtility.FromJson<T>(Encoding.UTF8.GetString(serializedData));
    }
    public static void Delete(string fileName)
    {
        var filePath = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
