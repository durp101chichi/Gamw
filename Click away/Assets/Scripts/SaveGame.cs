using UnityEngine;
using System.IO;
public class SaveSystem
{
    private static SaveGame saveData = new SaveGame();

    [System.Serializable]
    public struct SaveGame
    {
        public Vector3 Position;
        public int SceneId;
        public int DialogId;

    }

    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/save" + ".save";
        return saveFile;
    }

    public static void Save()
    {
        HandleSaveData();
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(saveData, true));
    }
    private static void HandleSaveData()
    {
    }

    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());

       saveData = JsonUtility.FromJson<SaveGame>(saveContent);
        HandleLoadData();
    }
    private static void HandleLoadData()
    {

    }
}
