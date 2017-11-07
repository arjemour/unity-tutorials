using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float AutoLoadNextLevelAfter;

    private void Start()
    {
        if (AutoLoadNextLevelAfter > 0)
        {
            Invoke("LoadNextLevel", AutoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}