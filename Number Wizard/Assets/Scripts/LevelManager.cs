using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        print("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitLevel()
    {
        print("Quit");
        Application.Quit();
    }
}