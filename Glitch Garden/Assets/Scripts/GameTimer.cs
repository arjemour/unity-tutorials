using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float LevelTimer;

    private Slider slider;
    private AudioSource audioSource;
    private bool levelEnded = false;
    private LevelManager levelManager;
    private GameObject winLabel;

    // Use this for initialization
    private void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        winLabel = GameObject.Find("Win");
        winLabel.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        slider.value = 1 - (Time.timeSinceLevelLoad / LevelTimer);
        if (Time.timeSinceLevelLoad >= LevelTimer && !levelEnded)
        {
            audioSource.Play();
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
            levelEnded = true;
        }
    }

    private void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}