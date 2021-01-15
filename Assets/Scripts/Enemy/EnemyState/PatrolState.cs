using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    // public static PatrolState Instance {get; private set;}
    // static PatrolState()
    // {
    //     Instance = new PatrolState();
    //     Debug.Log("new PatrolState");
    // }
    public override void Stay(EnemyTank enemy)
    {
        enemy.RandomMove();
        if(enemy.currentHealth <= 0)
        {
            enemy.ChangeState(EnemyState.Die);
        }
        if(enemy.DistanceToPalyer() <= enemy.property.ViewRange)
        {
            enemy.ChangeState(EnemyState.Aware);
        }
    }
}
