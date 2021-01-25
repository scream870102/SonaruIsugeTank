using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eccentric.Utils;

public class test : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }    
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log("transform.up: " + transform.up);
        Debug.Log("Vector3.up: " + Vector3.up);
    }
}
