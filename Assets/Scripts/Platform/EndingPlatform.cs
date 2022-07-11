using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingPlatform : Platform
{
    public EndingPlatform() : base(true)
    {
    }

    protected override void HandleCollisionEnter(GameObject player)
    {
        SceneManager.LoadScene(1);
    }
}