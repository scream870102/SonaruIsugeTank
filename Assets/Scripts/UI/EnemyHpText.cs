using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpText : MonoBehaviour
{
    [SerializeField]Text enemyName=null;
    [SerializeField] Image enemyBar=null;
    EnemyHpBar enemyHPBar = null;

    // Start is called before the first frame update
    void Start()
    {
        enemyName.text = "";
        enemyHPBar = enemyBar.GetComponent<EnemyHpBar>();
    }

    // Update is called once per frame
    void Update() => enemyName.text =enemyHPBar.EnemyName;
}
