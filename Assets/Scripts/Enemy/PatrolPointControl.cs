using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPointControl : MonoBehaviour
{
    public Transform StartPt;
    public Transform CtrlPt_1;
    public Transform CtrlPt_2;
    public Transform EndPt;

    public int segmentNum;



    void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        SetCurve();    
    }

    void SetCurve()
    {
        for(int i = 0; i < segmentNum; i++)
        {
            float t = i / (float)segmentNum;
            Gizmos.DrawSphere(CalBezier(t, StartPt.position, CtrlPt_1.position, CtrlPt_2.position, EndPt.position), 0.01f);
        }
        for(int j = 0; j < (segmentNum - 1); j++)
        {
            float ct = j / (float)segmentNum;
            float nt = ( j + 1.0f ) / (float)segmentNum;
            Gizmos.DrawLine(CalBezier(ct, StartPt.position, CtrlPt_1.position, CtrlPt_2.position, EndPt.position),
                            CalBezier(nt, StartPt.position, CtrlPt_1.position, CtrlPt_2.position, EndPt.position));
        }
    }

    Vector3 CalBezier(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        Vector3 res = (u * u * u * p0) + (3 * t * u * u * p1) + (3 * t * t * u * p2) + (t * t * t * p3);
        return res;
    }
}
