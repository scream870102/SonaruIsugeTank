using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public abstract void Enter(EnemyTank enemy);
    public abstract void Stay(EnemyTank enemy);
    public abstract void Exit(EnemyTank enemy);
}
   
