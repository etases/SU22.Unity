using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("DraftMap", LoadSceneMode.Single);
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Single);
    }
}
