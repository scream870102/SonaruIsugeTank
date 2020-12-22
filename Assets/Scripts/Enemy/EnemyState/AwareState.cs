using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwareState : State
{
    public static AwareState Instance {get; private set;}
    static AwareState()
    {
        Instance = new AwareState();
        Debug.Log("new AwareState");
    }
    public override void Stay(EnemyTank enemy)
    {        
        enemy.LookTarget();
        if(enemy.currentHealth <= 0)
        {
            enemy.ChangeState(new DieState());
        }
        if(enemy.DistanceToPalyer() <= enemy.property.AttackRange)
        {
            enemy.ChangeState(new AttackState());
        }
        if(enemy.DistanceToPalyer() > enemy.property.ViewRange)
        {
            enemy.ChangeState(new PatrolState());
        }
    }
}
