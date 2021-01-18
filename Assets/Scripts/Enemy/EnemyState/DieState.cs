using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    public override void Enter(EnemyTank enemy)
    {

    }
    public override void Stay(EnemyTank enemy)
    {
        enemy.DestoryTank();
    }
    public override void Exit(EnemyTank enemy)
    {
        
    }
}
