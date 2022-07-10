using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingFlatform : Platform
{
    
    public EndingFlatform() : base(true) {}
    
    protected override void HandleCollisionEnter(GameObject player)
    {
        SceneManager.LoadScene(1);
    }

}
