using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float time;
    public int attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            Destroy(this.gameObject);
    }
}
