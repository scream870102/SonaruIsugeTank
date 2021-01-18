using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public override void Enter(EnemyTank enemy)
    {

    }
    public override void Stay(EnemyTank enemy)
    {
        enemy.RandomMove();
        //enemy.LookTarget(enemy.gameObject);
        if(enemy.currentHealth <= 0)
        {
            enemy.ChangeState(EnemyState.Die);
        }
        if(enemy.DistanceToPalyer() <= enemy.property.ViewRange)
        {
            enemy.ChangeState(EnemyState.Aware);
        }
    }
    public override void Exit(EnemyTank enemy)
    {
        
    }
}
