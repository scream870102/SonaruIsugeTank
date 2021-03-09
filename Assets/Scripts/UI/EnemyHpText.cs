using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpText : MonoBehaviour
{
    [SerializeField]Text enemyName=null;

    void OnEnable()
    {
        EnemyTank.EnemyHpChange += UpdateEnemyHpText;
    }
    
    void OnDisable()
    {
        EnemyTank.EnemyHpChange -= UpdateEnemyHpText;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyName.text = "";
    }

    void UpdateEnemyHpText(EnemyTank sender, int currentHealth)
    {
        enemyName.text = sender.property.Name;
    }
}
