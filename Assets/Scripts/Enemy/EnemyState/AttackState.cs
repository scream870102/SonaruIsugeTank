using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public static AttackState Instance {get; private set;}
    static AttackState()
    {
        Instance = new AttackState();
        Debug.Log("new AttackState!");
    }
    public override void Stay(EnemyTank enemy)
    {
        enemy.LookTarget();
        enemy.ShootTarget();
        if(enemy.currentHealth <= 0)
        {
            enemy.ChangeState(new DieState());
        }
        if(enemy.DistanceToPalyer() > enemy.property.AttackRange)
        {
            enemy.ChangeState(new AwareState());
        }
    }
}
