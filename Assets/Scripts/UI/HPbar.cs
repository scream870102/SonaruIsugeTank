using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public Image HpBarImg;
    public GameObject player;
    private float currentHealth;
    private float playerHealth;
    private float HPpercent;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<Player>().property.health;
        currentHealth = player.GetComponent<Player>().currentHealth;
        HPpercent = currentHealth / playerHealth;
        HpBarImg.color = Color.Lerp (Color.red, Color.green, HPpercent);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            currentHealth = player.GetComponent<Player>().currentHealth;
            HPpercent = currentHealth / playerHealth;
            HpBarImg.fillAmount = Mathf.Lerp(0.25f, 1, HPpercent);
            HpBarImg.color = Color.Lerp(Color.red, Color.green, HPpercent);
        }
    }
}
