using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int breakableCount;
    public Sprite[] HitSprites;
    private bool isBreakable;
    private LevelManager levelManager;
    private int timesHit;

    // Use this for initialization
    private void Start()
    {
        isBreakable = tag == "Breakable";
        if (isBreakable)
            breakableCount += 1;
        levelManager = FindObjectOfType<LevelManager>();
        timesHit = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
            HandleHits();
    }

    private void HandleHits()
    {
        var maxHits = HitSprites.Length + 1;

        timesHit++;

        if (timesHit >= maxHits)
        {
            breakableCount -= 1;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        var spriteIndex = timesHit - 1;
        if (HitSprites[spriteIndex])
            GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
    }

    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}