using System.IO;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public bool saveOnDestroy;
    private string m_Path;
    // Start is called before the first frame update
    public Data data { get; private set; }

    private void Awake()
    {
        m_Path = Application.persistentDataPath + "/data.json";
        LoadData();
    }

    private void LoadData()
    {
        if (File.Exists(m_Path))
        {
            var dataAsJson = File.ReadAllText(m_Path);
            data = JsonUtility.FromJson<Data>(dataAsJson);
            Debug.Log("Loaded data from " + m_Path);
        }

        if (data != null) return;
        data = new Data();
        Debug.Log("Created new data");
    }

    public void SaveData()
    {
        var dataAsJson = JsonUtility.ToJson(data, true);
        File.WriteAllText(m_Path, dataAsJson);
    }

    public void ResetData()
    {
        data = new Data();
        SaveData();
    }

    private void OnDestroy()
    {
        Debug.Log("Saving data");
        if (saveOnDestroy)
        {
            SaveData();
        }
    }
}

public class Data
{
    public float bgm = 1;
    public float sfx = 1;
    public bool remake = false;
    public bool hasPlayerSaved;
    public Vector3 location;
    public Vector2 velocity = Vector2.zero;
    public bool isGrounded;
    public float jumpSpeed = Jumper.dJumpSpeed;
    public float walkSpeed = Jumper.dWalkSpeed;

    public void ResetPlayer()
    {
        hasPlayerSaved = false;
        location = Vector3.zero;
        velocity = Vector2.zero;
        isGrounded = false;
        jumpSpeed = Jumper.dJumpSpeed;
        walkSpeed = Jumper.dWalkSpeed;
    }
}
