using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    private Storage m_Storage;
    
    private void Start()
    {
        m_Storage = FindObjectOfType<Storage>();
        if (m_Storage == null)
        {
            throw new Exception("Storage not found");
        }
    }

    private void Update()
    {
        if (m_Storage.data.remake)
        {
            SceneManager.LoadScene("RemakeMap", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("NormalMap", LoadSceneMode.Single);
        }
    }
}