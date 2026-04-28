using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
public static class SystemDataManager
{
    public static void SaveBestScore(Player player) 
    {
        FileStream archive = CreateStream("/playerData.player", FileMode.Create);
        BinaryFormatter formatter = new();
        formatter.Serialize(archive, player);
        archive.Close();
    }

    public static Player LoadBestScore()
    {
        FileStream archive = CreateStream("/playerData.player", FileMode.Open);
        BinaryFormatter formatter = new();
        Player bestScore = (Player) formatter.Deserialize(archive);
        archive.Close();
        return bestScore;
    }

    private static FileStream CreateStream(string path, FileMode mode)
    {
        string finalPath = Application.persistentDataPath + path;
        return new FileStream(finalPath, mode);
    }
}
