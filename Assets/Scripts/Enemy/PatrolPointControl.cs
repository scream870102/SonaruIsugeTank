using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPointControl : MonoBehaviour
{
    public float MAX_AVOID_FORCE = 1.1f;
    public Transform StartPt;
    public Transform CtrlPt_1;
    public Transform CtrlPt_2;
    public Transform EndPt;

    public int segmentNum;

    private List<Vector3> pointList;
    private List<Vector3> fixList;

    private Vector3 setPoint;
    void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        SetCurve();    
    }

    void SetCurve()
    {
        pointList = new List<Vector3>();
        fixList = new List<Vector3>();
        //標示點位置
        for(int i = 1; i <= segmentNum; i++)
        {
            float t = i / (float)segmentNum;
            Gizmos.DrawSphere(CalBezier(t, StartPt.position, CtrlPt_1.position, CtrlPt_2.position, EndPt.position), 0.01f);
            pointList.Add(CalBezier(t, StartPt.position, CtrlPt_1.position, CtrlPt_2.position, EndPt.position));
        }
        //畫出曲線
        for(int j = 1; j <= (segmentNum - 1); j++)
        {
            Vector3 cv = pointList[j-1];
            Vector3 nv = pointList[j];
            Ray2D ray = new Ray2D(cv, nv-cv);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Vector3.Distance(cv, nv) + 2, 1<<8);
            if(hit.collider)
            {
                Vector3 fixPoint = new Vector3(setPoint.x, cv.y, 0);
                fixList.Add(fixPoint); 
                Gizmos.color = Color.red;
            }
            else
            {
                setPoint = cv;
                Gizmos.color = Color.blue;
            }
            Gizmos.DrawLine(cv, nv);
        }
        for(int k = 0; k < fixList.Count - 1; k++)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(fixList[k], fixList[k+1]);
        }
    }

    Vector3 CalBezier(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        Vector3 res = (u * u * u * p0) + (3 * t * u * u * p1) + (3 * t * t * u * p2) + (t * t * t * p3);
        return res;
    }
}
