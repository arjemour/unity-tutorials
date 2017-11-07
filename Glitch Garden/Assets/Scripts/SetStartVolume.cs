using UnityEngine;

public class SetStartVolume : MonoBehaviour
{
    private MusicManager musicManager;

    // Use this for initialization
    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        
        if (musicManager)
        {
            float volume = PlayerPrefsManager.GetMasterVolume();
            if (volume >= 0 && volume <= 1)
            {
                musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}