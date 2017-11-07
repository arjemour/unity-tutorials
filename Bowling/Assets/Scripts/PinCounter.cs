using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour
{
    public Text StandingDisplay;

    private bool _ballOutOfPlay = false;
    private int LastStandingCount = -1;
    private float _lastChangedTime;
    private int _lastSettledCount = 10;
    private GameManager _gameManager;

    // Use this for initialization
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        StandingDisplay.text = CountStanding().ToString();

        if (_ballOutOfPlay)
        {
            CheckStanding();
            StandingDisplay.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            _ballOutOfPlay = true;
        }
    }

    public void Reset()
    {
        _lastSettledCount = 10;
    }

    private void CheckStanding()
    {
        int currentStanding = CountStanding();

        if (currentStanding != LastStandingCount)
        {
            _lastChangedTime = Time.time;
            LastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3;

        if ((Time.time - _lastChangedTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    private int CountStanding()
    {
        int standing = 0;

        foreach (Pin pin in FindObjectsOfType<Pin>())
            if (pin.IsStanding())
                standing++;

        return standing;
    }

    private void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = _lastSettledCount - CountStanding();
        _lastSettledCount = standing;
        _gameManager.Bowl(pinFall);

        LastStandingCount = -1;
        _ballOutOfPlay = false;
        StandingDisplay.color = Color.green;
    }
}