using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    public Image EnemyHpImg;
    public GameObject Enemy;
    public string EnemyName;
    private float currentHealth;
    private float health;
    private float healthPercent;
    private bool ImgAlpha = false;
    private float countTime = 5f;
    void Start(){
        Enemy = null;
        SetHpBarAlpha(ImgAlpha);
    }

    // Update is called once per frame
    void Update()
    {   
        SetHpBarAlpha(ImgAlpha);
        if(Enemy != null)
        {
            countTime = 5f;
            ImgAlpha = true;
            currentHealth = Enemy.GetComponent<EnemyTank>().currentHealth;
            health = Enemy.GetComponent<EnemyTank>().property.health;
            healthPercent = currentHealth / health;
            EnemyHpImg.fillAmount = healthPercent;
            EnemyName = Enemy.GetComponent<EnemyTank>().property.Name;
            Enemy = null;
        }
        else 
        {
            countTime -= Time.deltaTime;
            if(countTime <= 0f)
            {
                ImgAlpha = false;
            }
        }
    }

    void SetHpBarAlpha(bool b)
    {
        if(b)
        {
            EnemyHpImg.GetComponentInParent<CanvasGroup>().alpha = 1;    
        }
        else EnemyHpImg.GetComponentInParent<CanvasGroup>().alpha = 0;
    }
}
