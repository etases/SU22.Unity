using System.IO;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private string _path;
    // Start is called before the first frame update
    public Data Data { get; private set; }

    void Awake()
    {
        _path = Application.persistentDataPath + "/data.json";
        LoadData();
    }

    void LoadData()
    {
        if (File.Exists(_path))
        {
            string dataAsJson = File.ReadAllText(_path);
            Data = JsonUtility.FromJson<Data>(dataAsJson);
            Debug.Log("Loaded data from " + _path);
        }
        else
        {
            Data = new();
            Debug.Log("Created new data");
        }
    }

    public void SaveData()
    {
        string dataAsJson = JsonUtility.ToJson(Data, true);
        File.WriteAllText(_path, dataAsJson);
    }

    public void ResetData()
    {
        Data = new();
        SaveData();
    }

    void OnDestroy()
    {
        SaveData();
    }
}

public class Data
{
    public float bgm = 1;
    public float sfx = 1;
    public string location = string.Empty;
}
