using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScene", LoadSceneMode.Single);
    }

    public void OpenSettings()
    {
        PauseMenu.gameIsPaused = false;
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Single);
    }
}