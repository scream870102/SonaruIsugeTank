using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankType", menuName = "Create Type")]
public class TankProperty : ScriptableObject
{
    public string Name;
    public int Id;
    public int attack;
    public int health;
    public float MoveSpeed;
    public float RotateSpeed;
    public float HeadRotSpeed;
    public float ShootSpeed;
    public float ReloadTime;
    public int ViewRange;
}
