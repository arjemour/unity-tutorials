using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider VolumeSlider;
    public Slider DifficultySlider;
    public LevelManager LevelManager;
    private MusicManager musicManager;

    // Use this for initialization
    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        VolumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        DifficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    // Update is called once per frame
    private void Update()
    {
        musicManager.ChangeVolume(VolumeSlider.value);
    }

    public void SetDefault()
    {
        PlayerPrefsManager.SetMasterVolume(0.25f);
        PlayerPrefsManager.SetDifficulty(2);
        VolumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        DifficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(VolumeSlider.value);
        PlayerPrefsManager.SetDifficulty(DifficultySlider.value);
        LevelManager.LoadLevel("01a Start");
    }
}