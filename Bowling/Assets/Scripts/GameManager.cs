using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<int> _bowls = new List<int>();
    private PinSetter _pinSetter;
    private Ball _ball;

    // Use this for initialization
    private void Start()
    {
        _pinSetter = FindObjectOfType<PinSetter>();
        _ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Bowl(int pinFall)
    {
        _bowls.Add(pinFall);
        ActionMaster.Action nextAction = ActionMaster.NextAction(_bowls);
        _pinSetter.PerformAction(nextAction);
        _ball.Reset();
    }
}