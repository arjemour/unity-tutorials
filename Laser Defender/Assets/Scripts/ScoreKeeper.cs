using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text ScoreText;
    public int score;

    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        ScoreText.text = "0";
        score = 0;
    }

    public void IncreaseScore(int count)
    {
        score += count;
        ScoreText.text = score.ToString();
    }
}