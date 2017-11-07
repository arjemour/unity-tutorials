using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

public class ActionMasterTest
{
    //public ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    //public ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    //public ActionMaster.Action reset = ActionMaster.Action.Reset;
    //public ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    //private ActionMaster _actionMaster; 

    //[SetUp]
    //public void Setup()
    //{
    //    _actionMaster = new ActionMaster();
    //}

    //[Test]
    //public void T00PassingTest()
    //{
    //    Assert.AreEqual(1, 1);
    //}

    //[Test]
    //public void T01OneStrikeReturnsEndTurn()
    //{
    //    Assert.AreEqual(endTurn, _actionMaster.Bowl(10));
    //}

    //[Test]
    //public void T02Bow8ReturnsTidy()
    //{
    //    Assert.AreEqual(tidy, _actionMaster.Bowl(8));
    //}

    //[Test]
    //public void T03Bow28ReturnsEndTurn()
    //{
    //    _actionMaster.Bowl(8);
    //    Assert.AreEqual(endTurn, _actionMaster.Bowl(2));
    //}

    //[Test]
    //public void T04CheckResetAtStrikeInLastFrame()
    //{
    //    int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
    //    foreach (int roll in rolls)
    //    {
    //        _actionMaster.Bowl(roll);
    //    }
    //    Assert.AreEqual(reset, _actionMaster.Bowl(10));
    //}

    //[Test]
    //public void T05CheckResetAtSpareInLastFrame()
    //{
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    //    foreach (int roll in rolls)
    //    {
    //        _actionMaster.Bowl(roll);
    //    }
    //    _actionMaster.Bowl(1);
    //    Assert.AreEqual(reset, _actionMaster.Bowl(9));
    //}

    //[Test]
    //public void T06RollsEndInEndGame()
    //{
    //    int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2};
    //    foreach (int roll in rolls)
    //    {
    //        _actionMaster.Bowl(roll);
    //    }
    //    Assert.AreEqual(endGame, _actionMaster.Bowl(9));
    //}

    //[Test]
    //public void T07GameEndsAtBowl20()
    //{
    //    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
    //    foreach (int roll in rolls)
    //    {
    //        _actionMaster.Bowl(roll);
    //    }
    //    Assert.AreEqual(endGame, _actionMaster.Bowl(1));
    //}
}