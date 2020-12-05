using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    public GameObject head;
    public Transform gun;
    public Transform shootPoint;
    public TankProperty property;
    public GameObject bullet;
    private Player player;
    public int currentHealth;

    void Start()
    {
        player = new Player(head, gun, shootPoint, property, bullet);
        currentHealth = property.health;
    }
    // Update is called once per frame
    void Update()
    {
        player.HeadControl();
        player.Shoot();
        DestoryTank();
    }
    void OnCollisionEnter2D(Collision2D bul)
    {
        if (bul.gameObject.tag == "Bullet")
        {
            currentHealth -= bul.gameObject.GetComponent<Bullet>().attack;
        }
    }
    void DestoryTank()
    {
        if(currentHealth <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
}
