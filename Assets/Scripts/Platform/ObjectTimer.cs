using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectTimer : MonoBehaviour
{

    public GameObject obj;

    

    // Update is called once per frame
    void Update()
    {

    }




    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(DisableObject(obj, 2.0f));
        }
    }

    IEnumerator DisableObject(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }

    public void ActiveObject()
    {
        obj.SetActive(true);
    }
    
    // void TogglePlatform()
    // {
    //
    //     foreach (Transform child in gameObject.transform)
    //     {
    //         if(child.tag != "Player")
    //         {
    //             
    //             child.gameObject.SetActive(enable);
    //         }
    //     }
    // }

}