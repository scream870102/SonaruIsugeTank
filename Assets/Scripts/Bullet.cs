using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float time;
    public int attack;
    public int Team;
    public GameObject bar;

    void Awake() => bar = FindObjectOfType<EnemyHpBar>().gameObject;
    
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time < 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        bar.GetComponent<EnemyHpBar>().Enemy = Get_Enemy_GameObject(col);
        Destroy(this.gameObject);
    }
    
    public GameObject Get_Enemy_GameObject(Collision2D col){
        if(col.gameObject.CompareTag("Enemy") && Team != 0){
            return col.gameObject;
        }
        return null;
    }
}
