using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetting : MonoBehaviour
{
    public GameObject head;
    public Transform gun;
    public Transform shootPoint;
    public TankProperty property;
    private GameObject player;
    public GameObject bullet;
    private Enemy enemy;
    [SerializeField] private int currentHealth;

    void Start()
    {
        player = FindObjectOfType<PlayerControl>().gameObject;
        enemy = new Enemy(head, gun, shootPoint, property, player, bullet);
        currentHealth = property.health;
    }

    void Update()
    {
        enemy.LookTarget();
        enemy.ShootTarget();
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
