using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    public List<Vector3> CreaterPoint;
    public int EnemyAmount;

    public GameObject Enemy;


    void Awake() 
    {
        if(CreaterPoint.Count < EnemyAmount)
        {
            Debug.LogError("CreaterPoint amounts are overflow!");
        }    
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
