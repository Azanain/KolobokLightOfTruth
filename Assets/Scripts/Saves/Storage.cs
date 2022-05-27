using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Storage
{
    private string filePath;
    private BinaryFormatter formatter;
    public Storage()
    {
        formatter = new BinaryFormatter();
    }
    public object Load(object saveDataByDefault)
    {
        filePath = Application.persistentDataPath + "/saves/GameSave.save";
        if (!File.Exists(filePath))
        {
            if (saveDataByDefault != null)
            {
                Save(saveDataByDefault);
                return saveDataByDefault;
            }
        }
        var file = File.Open(filePath, FileMode.Open);

        var saveData = formatter.Deserialize(file);
        file.Close();
        return saveData;
    }
    public void Save(object saveData)
    {
        var dir = Application.persistentDataPath + "/saves";
        filePath = dir + "/GameSave.save";
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        var file = File.Create(filePath);
        formatter.Serialize(file, saveData);
        file.Close();
    }
}
