using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string MASTER_VOLUME_KEY = "master_volume";
    private const string DIFFICULTY_KEY = "difficulty";
    private const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume)
    {
        if (volume > 0 && volume < 1)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt($"{LEVEL_KEY}{level}", 1);
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt($"{LEVEL_KEY}{level}");
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 1)
            return isLevelUnlocked;

        return false;
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty > 0 && difficulty < 4)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}