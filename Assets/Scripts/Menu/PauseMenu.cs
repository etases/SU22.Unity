using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Storage storage;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Toggle bgmToggle;
    public Toggle sfxToggle;
    // Start is called before the first frame update
    void Start()
    {
        bgmToggle.isOn = storage.Data.bgm > 0;
        sfxToggle.isOn = storage.Data.sfx > 0;
        bgmSlider.value = bgmToggle.isOn ? Random.Range(0.1f, 1) : 0;
        sfxSlider.value = sfxToggle.isOn ? Random.Range(0.1f, 1) : 0;
    }

    public void SaveGame()
    {
        storage.SaveData();
    }

    public void ResetGame()
    {
        storage.ResetData();
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void BGMSliderChange()
    {
        storage.Data.bgm = bgmSlider.value;
        bgmToggle.isOn = storage.Data.bgm != 0;
    }

    public void BGMToggleChange()
    {
        storage.Data.bgm = bgmToggle.isOn ? 1 : 0;
        bgmSlider.value = storage.Data.bgm > 0 ? Random.Range(0.1f, 1) : 0;
    }

    public void SFXSliderChange()
    {
        storage.Data.sfx = sfxSlider.value;
        sfxToggle.isOn = storage.Data.sfx != 0;
    }

    public void SFXToggleChange()
    {
        storage.Data.sfx = sfxToggle.isOn ? 1 : 0;
        sfxSlider.value = storage.Data.sfx > 0 ? Random.Range(0.1f, 1) : 0;
    }
}
