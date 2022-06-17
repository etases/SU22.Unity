using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlatform : MonoBehaviour
{
    private GameObject go;

    public float timer;

    public float timeRemaining = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.FindWithTag("InviPlatform");
    }

    // Update is called once per frame
    void Update()
    {
        if(!go.activeInHierarchy)
        {
            timer += Time.deltaTime;
            if(timer >= timeRemaining)
            {
                go.SetActive(true);
                timer = 0.0f;
            }
        }
    }
    
}
