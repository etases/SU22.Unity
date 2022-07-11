using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningScript : MonoBehaviour
{
    private Storage m_Storage;

    private void Start()
    {
        m_Storage = FindObjectOfType<Storage>();
        if (m_Storage == null) throw new Exception("Storage not found");
        
        m_Storage.data.ResetPlayer();
        m_Storage.SaveData();
        PlayerPrefs.DeleteAll();
    }

    public void BackBackPressed()
    {
        m_Storage.data.ResetPlayer();
        m_Storage.SaveData();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
