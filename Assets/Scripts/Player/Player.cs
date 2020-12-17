using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    public GameObject Head;
    public Transform Gun;
    public Transform ShootPoint;
    public GameObject Bullet;
    private GameObject BulletClone;
    public TankProperty property;
    public GameObject player;
    protected float CountTime = 0;

    public Player(GameObject _head, Transform _gun, Transform _point, TankProperty _property, GameObject _bullet)
    {
        Head = _head;
        Gun = _gun;
        ShootPoint = _point;
        property = _property;
        Bullet = _bullet;
    }
    public void HeadControl()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Vector3 direction = worldPos - Head.transform.position;
        direction.z = 0f;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Head.transform.rotation = Quaternion.Slerp(Head.transform.rotation, Quaternion.Euler(0, 0, -angle), property.HeadRotSpeed * Time.deltaTime);
    }
    public void Shoot()
    {
        CountTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(CountTime >= property.ReloadTime)
            {
                InitBullet();
                CountTime = 0;
            }
        }
    }
    private void InitBullet()
    {
        Vector3 pos = ShootPoint.transform.position;
        Quaternion rot = ShootPoint.transform.rotation;
        BulletClone = GameObject.Instantiate(Bullet, pos, rot);
        BulletClone.GetComponent<SpriteRenderer>().color = new Color(0.17f, 0.7f, 0.32f);
        BulletClone.GetComponent<Rigidbody2D>().velocity = Gun.up * property.BulletSpeed;//給予砲彈初速
        BulletClone.GetComponent<Bullet>().attack = property.attack;        
        BulletClone.GetComponent<Bullet>().id = property.Id;
    }
}
