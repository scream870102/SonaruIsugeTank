using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CircleCal.Math;

public class EnemyTank : MonoBehaviour
{
    //當前狀態
    public State CurrentState;

    public GameObject EnemyHead;
    public Transform EnemyGun;
    public Transform EnemyShootPoint;
    public GameObject Bullet;
    private GameObject BulletClone;
    public TankProperty property;
    public GameObject player;
    private float CountTime = 0;
    public int currentHealth;

    // Start is called before the first frame update
    void Awake()
    {
        CurrentState = new PatrolState();
        currentHealth = property.health;
        player = FindObjectOfType<PlayerSetting>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.Stay(this);
        //Debug.Log(CurrentState);
    }

    //設定扣血
    void OnCollisionEnter2D(Collision2D bul)
    {
        if (bul.gameObject.tag == "Bullet")
        {
            currentHealth -= bul.gameObject.GetComponent<Bullet>().attack;
        }
    }

    //偵錯用(畫圓)
    void OnDrawGizmos()
	{
		DrawCircle(EnemyHead.transform.position, property.AttackRange, Color.red);
        DrawCircle(EnemyHead.transform.position, property.ViewRange, Color.green);
	}

    //改變狀態
    public void ChangeState(State newState)
    {
        CurrentState = newState;
    }

    //計算與玩家間的距離
    public float DistanceToPalyer()
    {
        return Vector2.Distance(player.transform.position, EnemyHead.transform.position);
    }

    public void RandomMove()
    {
            
    }

    //敵人瞄準玩家
    public void LookTarget()
    {
        if(player != null)
        {
            Vector3 targetPos = player.transform.position;
            Vector3 direction = targetPos - EnemyHead.transform.position;
            direction.z = 0f;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            EnemyHead.transform.rotation = Quaternion.Slerp(EnemyHead.transform.rotation, Quaternion.Euler(0, 0, -angle), property.HeadRotSpeed * Time.deltaTime);
        }
    }

    //敵人射擊
    public void ShootTarget()
    {
        CountTime += Time.deltaTime;
        Ray2D ray = new Ray2D(EnemyShootPoint.position, EnemyGun.up);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider && hit.collider.name == "Player")
        {
            if (CountTime >= property.ReloadTime)
            {
                EnemyBulletShoot(Bullet, property.BulletSpeed);
                CountTime = 0;
            }
            Debug.DrawLine(ray.origin,hit.point, Color.red );
        }
    }

    //設定子彈生成與前進
    private void EnemyBulletShoot(GameObject bullet, float speed)
    {
        Vector3 pos = EnemyShootPoint.position;
        Quaternion rot = EnemyShootPoint.rotation;
        BulletClone = GameObject.Instantiate(bullet, pos, rot);
        BulletClone.GetComponent<SpriteRenderer>().color = new Color(0.16f, 0.62f, 0.9f);
        BulletClone.GetComponent<Rigidbody2D>().velocity = EnemyGun.up * speed;
        BulletClone.GetComponent<Bullet>().attack = property.attack;
        BulletClone.GetComponent<Bullet>().id = property.Id;
    }

    //消滅
    public void DestoryTank()
    {
        Destroy(this.gameObject);
    }



    //偵錯用(畫攻擊範圍、視野範圍)
    [ExecuteInEditMode]
    public void DrawCircle(Vector2 _center, float _radius, Color _color)
    {
        Circle2d circle = new Circle2d(_center, _radius);
        int count = 40;
        float delta = (2f * Mathf.PI) / count;
        Vector2 prev = circle.Eval(0);

        Color tempColor = Gizmos.color;
		Gizmos.color = _color;

        for(int i = 0; i <= count; i++)
        {
            Vector3 curr = circle.Eval(i * delta);
            Gizmos.DrawLine(prev, curr);
            prev = curr;
        }

        Gizmos.color = tempColor;
    }
}
