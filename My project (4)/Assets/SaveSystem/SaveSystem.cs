using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
	public static void SaveGame(int slotIndex)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + $"/gameData{slotIndex}.sus";
		FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = SaveManager.instance.data;

        formatter.Serialize(stream, data);
		stream.Close();
	}
	
	public static GameData LoadGame(int slotIndex)
	{
		string path = Application.persistentDataPath + $"/gameData{slotIndex}.sus";
		if(File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);
			
			GameData data = formatter.Deserialize(stream) as GameData;
			stream.Close();
			
			return data;
		}else
		{
			Debug.LogWarning("Save file not found in " + path + ", loading default values.");
			return new GameData();
		}
	}

	public static bool LoadGameIfExists(int slotIndex, out GameData saveGame)
	{
        string path = Application.persistentDataPath + $"/gameData{slotIndex}.sus";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

			saveGame = data;
            return true;
        }
        else
        {
            Debug.LogWarning("Save file not found in " + path + ", returning null.");
			saveGame = null;
            return false;
        }
    }
}