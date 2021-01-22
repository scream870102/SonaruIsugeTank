using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public override void Enter(EnemyTank enemy)
    {
        enemy.InitPatrolPoint(enemy.transform.position, enemy.BezierCtrlPt[0].position, enemy.BezierCtrlPt[1].position, enemy.BezierCtrlPt[2].position);
    }
    public override void Stay(EnemyTank enemy)
    {
        enemy.CurveMove();

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
