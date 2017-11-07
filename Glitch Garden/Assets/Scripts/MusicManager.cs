using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] LevelMusicChangeArray;

    private AudioSource audioSource;

    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnLevelWasLoaded(int level)
    {
        if (LevelMusicChangeArray[level])
        {
            audioSource.clip = LevelMusicChangeArray[level];
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}