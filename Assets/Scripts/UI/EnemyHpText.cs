using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpText : MonoBehaviour
{
    public Text EnemyName;
    public Image EnemyBar;

    // Start is called before the first frame update
    void Start()
    {
        EnemyName.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        EnemyName.text = EnemyBar.GetComponent<EnemyHpBar>().EnemyName;
    }
}
