using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Eccentric.Utils;
using Lean.Pool;

public class Bullet : MonoBehaviour
{
    public float time;
    private ScaledTimer bulletDestroyTImer;
    public int attack;
    public int Team;
    public GameObject bar;

    void OnEnable() 
    {
        bulletDestroyTImer.Reset();
    }

    void Awake()
    {
        bar = FindObjectOfType<EnemyHpBar>().gameObject;
        bulletDestroyTImer = new ScaledTimer(time);   
    }
    
    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(9, 9);
        if(bulletDestroyTImer.IsFinished)
        {
            LeanPool.Despawn(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        bar.GetComponent<EnemyHpBar>().Enemy = Get_Enemy_GameObject(col);
        if(col.gameObject.tag != null)
        {
            LeanPool.Despawn(gameObject);
        }
        //Debug.Log("Collision2D Name: " + col.gameObject.name.ToString() + " Frame: " + Time.frameCount);
    }
    
    public GameObject Get_Enemy_GameObject(Collision2D col){
        if(col.gameObject.CompareTag("Enemy") && Team != 0){
            return col.gameObject;
        }
        return null;
    }
}
