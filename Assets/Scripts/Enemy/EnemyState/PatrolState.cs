using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public static PatrolState Instance {get; private set;}
    static PatrolState()
    {
        Instance = new PatrolState();
        Debug.Log("new PatrolState");
    }
    public override void Stay(EnemyTank enemy)
    {
        if(enemy.currentHealth <= 0)
        {
            enemy.ChangeState(new DieState());
        }
        if(enemy.DistanceToPalyer() <= enemy.property.ViewRange)
        {
            enemy.ChangeState(new AwareState());
        }
    }
}
