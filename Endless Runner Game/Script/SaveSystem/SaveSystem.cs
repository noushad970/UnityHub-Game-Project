using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem 
{
    public static void SavePlayer(GameOver playerStat)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/profile.Dat";
        FileStream stream= new FileStream(path,FileMode.Create);
        GameData data = new GameData(playerStat);

        formatter.Serialize(stream, data);
        stream.Close();

    }
    public static GameData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/profile.Dat";
        if(File.Exists(path))
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream stream=new FileStream(path,FileMode.Open);

            GameData data = Formatter.Deserialize(stream) as GameData;
            stream.Close() ;
            return data;
        }
        else
        {
            return null;
        }


    }
}
