using UnityEngine;

public class Lose : MonoBehaviour
{
    private LevelManager levelManager;

    // Use this for initialization
    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D()
    {
        levelManager.LoadLevel("03B Lose");
    }
}