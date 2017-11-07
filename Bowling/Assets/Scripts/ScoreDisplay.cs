using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text[] RollTexts;
    public Text[] FrameTexts;

    // Use this for initialization
    private void Start()
    {
        RollTexts[0].text = "X";
        FrameTexts[0].text = 0.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}