using UnityEngine;

public class Defender : MonoBehaviour
{
    private StarDisplay starDisplay;
    public int starCost = 10;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }
}