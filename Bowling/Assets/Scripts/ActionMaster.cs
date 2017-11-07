using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
    public enum Action
    {
        Tidy,
        Reset,
        EndTurn,
        EndGame
    }

    private readonly int[] bowls = new int [21];
    private int _bowl = 1;

    public static Action NextAction(List<int> pinFalls)
    {
        ActionMaster am = new ActionMaster();
        Action currentAction = new Action();

        foreach (int pinFall in pinFalls)
        {
            currentAction = am.Bowl(pinFall);
        }

        return currentAction;
    }

    private Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10)
            throw new UnityException("Invalid pin count");

        bowls[_bowl - 1] = pins;

        if (_bowl == 21)
            return Action.EndGame;
        if (_bowl >= 19 && pins == 10)
        {
            _bowl++;
            return Action.Reset;
        }
        if (_bowl == 20)
        {
            _bowl++;
            if (bowls[19 - 1] == 10 && bowls[20 - 1] == 0)
                return Action.Tidy;
            if (bowls[19 - 1] + bowls[20 - 1] == 10)
                return Action.Reset;
            if (Bowl21Awarded())
                return Action.Tidy;
            return Action.EndGame;
        }
        if (_bowl % 2 != 0)
            if (pins == 10)
            {
                _bowl += 2;
                return Action.EndTurn;
            }
            else
            {
                _bowl += 1;
                return Action.Tidy;
            }
        if (_bowl % 2 == 0)
        {
            _bowl += 1;
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return");
    }

    private bool Bowl21Awarded()
    {
        return bowls[19 - 1] + bowls[20 - 1] >= 10;
    }
}