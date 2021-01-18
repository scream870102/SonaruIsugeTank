using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override void Enter(EnemyTank enemy)
    {

    }
    public override void Stay(EnemyTank enemy)
    {
        enemy.LookTarget(enemy.player);
        enemy.ShootTarget();
        if(enemy.currentHealth <= 0)
        {
            enemy.ChangeState(EnemyState.Die);
        }
        if(enemy.DistanceToPalyer() > enemy.property.AttackRange)
        {
            enemy.ChangeState(EnemyState.Aware);
        }
    }
    public override void Exit(EnemyTank enemy)
    {
        
    }
}
