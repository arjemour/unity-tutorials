using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        print("trigger");
        levelManager.LoadLevel("Lose Screen");
    }
}