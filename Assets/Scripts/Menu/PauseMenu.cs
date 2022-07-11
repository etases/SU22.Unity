using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    
    public Storage storage;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Toggle bgmToggle;
    public Toggle sfxToggle;
    public Toggle remakeToggle;
    
    // Start is called before the first frame update
    private void Start()
    {
        UpdateValues();
    }

    private void UpdateValues()
    {
        bgmToggle.isOn = storage.data.bgm > 0;
        sfxToggle.isOn = storage.data.sfx > 0;
        bgmSlider.value = storage.data.bgm;
        sfxSlider.value = storage.data.sfx;
        remakeToggle.isOn = storage.data.remake;
        remakeToggle.onValueChanged.AddListener(_ => RemakeToggleChange());
    }

    public void Home()
    {
        SceneManager.LoadScene(gameIsPaused ? "LoadingScene" : "MainMenu", LoadSceneMode.Single);
    }

    public void BGMSliderChange()
    {
        storage.data.bgm = bgmSlider.value;
        bgmToggle.isOn = storage.data.bgm != 0;
    }

    public void BGMToggleChange()
    {
        storage.data.bgm = bgmToggle.isOn ? 1 : 0;
        bgmSlider.value = storage.data.bgm > 0 ? Random.Range(0.1f, 1) : 0;
    }

    public void SFXSliderChange()
    {
        storage.data.sfx = sfxSlider.value;
        sfxToggle.isOn = storage.data.sfx != 0;
    }

    public void SFXToggleChange()
    {
        storage.data.sfx = sfxToggle.isOn ? 1 : 0;
        sfxSlider.value = storage.data.sfx > 0 ? Random.Range(0.1f, 1) : 0;
    }
    
    private void RemakeToggleChange()
    {
        Debug.Log("RemakeToggleChange");
        storage.data.remake = remakeToggle.isOn;
        storage.data.ResetPlayer();
    }
}
