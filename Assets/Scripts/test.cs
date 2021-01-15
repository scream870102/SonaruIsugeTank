using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eccentric.Utils;

public class test : MonoBehaviour
{
    ScaledTimer st;

    // Start is called before the first frame update
    void Start()
    {
        st = new ScaledTimer(10, false);
    }    
    
    // Update is called once per frame
    void Update()
    {
        // transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Debug.Log(st.Remain);
    }
}
