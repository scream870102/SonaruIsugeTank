using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    public Text HpText;
    public GameObject player;

    void OnEnable() 
    {
        Player.PlayerHpChange += UpdateHpText;
    }

    void OnDisable() 
    {
        Player.PlayerHpChange -= UpdateHpText;    
    }

    // Start is called before the first frame update
    void Start()
    {
        HpText.text = player.GetComponent<Player>().property.health.ToString();
    }

    public void UpdateHpText(int currentHealth)
    {
        if(player != null)
        {
            currentHealth = player.GetComponent<Player>().currentHealth;
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
