using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    public static DieState Instance {get; private set;}
    static DieState()
    {
        Instance = new DieState();
        Debug.Log("new DieState!");
    }
    public override void Stay(EnemyTank enemy)
    {
        enemy.DestoryTank();
    }
}
