using UnityEngine;

public class BGMScript : MonoBehaviour
{
    void Start()
    {
        var audioSource = GetComponent<AudioSource>();

        var storage = FindObjectOfType<Storage>();
        if (storage != null)
        {
            audioSource.volume = storage.data.bgm;
        }
    }
}
