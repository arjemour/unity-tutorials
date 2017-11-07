using System;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    private Text text;
    private int starAmount;

    public enum Status
    {
        SUCCESS,
        FAILURE
    }

    // Use this for initialization
    private void Start()
    {
        starAmount = 100;
        text = GetComponent<Text>();
        text.text = starAmount.ToString();
    }

    public void AddStars(int amount)
    {
        starAmount += amount;
        text.text = starAmount.ToString();
    }

    public Status UseStars(int amount)
    {
        if (starAmount >= amount)
        {
            starAmount -= amount;
            text.text = starAmount.ToString();
            return Status.SUCCESS;
        }

        return Status.FAILURE;
    }
}