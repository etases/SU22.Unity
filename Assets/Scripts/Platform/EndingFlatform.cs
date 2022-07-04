using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingFlatform : Platform
{
    
    protected override void HandleCollisionEnter(GameObject player)
    {
        SceneManager.LoadScene(1);
    }

}
