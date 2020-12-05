using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    public Text HpText;
    public GameObject player;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = player.GetComponent<PlayerSetting>().currentHealth;
        HpText.text = currentHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            currentHealth = player.GetComponent<PlayerSetting>().currentHealth;
            if(currentHealth <= 0)
            {
                HpText.text = "0";
            }
            else
            {
                HpText.text = currentHealth.ToString();
            }
        }
        
    }
}
