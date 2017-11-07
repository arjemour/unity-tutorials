using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{
    private int max;
    private int min;
    private int guess;

    public int maxGuessesAllowed = 10;

    public Text text;

    // Use this for initialization
    private void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    private void Update()
    {
        //if(Input.GetKeyDown((KeyCode.UpArrow)))
        //{
        //    min = guess;
        //    NextGuess();
        //}
        //else if (Input.GetKeyDown((KeyCode.DownArrow)))
        //{
        //    max = guess;
        //    NextGuess();
        //}
        //else if (Input.GetKeyDown((KeyCode.Return)))
        //{
        //    print("I won");
        //    StartGame();
        //}
    }

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }

    private void StartGame()
    {
        max = 1000;
        min = 1;
        NextGuess();

        //print("==============================================");
        //print("Welcome to number wizard");
        //print("Pick a number in your head, but don't tell me!");

        //print("The highest number you can pick is " + max);
        //print("The lowest number you can pick is " + min);

        //print("Is the number higher or lower than 500?");
        //print("Up = higher, down = lower, return = equal");
    }

    private void NextGuess()
    {
        guess = Random.Range(min, max + 1);
        text.text = guess.ToString();
        maxGuessesAllowed -= 1;
        if(maxGuessesAllowed == 0)
            SceneManager.LoadScene("Win");
        //print("Higher or lower than " + guess);
    }
}