using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//need to add those two package for savegame system
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
  public static void savePlayer(PLayer player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Gta5.saveData";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Gta5.saveData";

        if (File.Exists(path))
        {
            BinaryFormatter formatter= new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            PlayerData data= formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
