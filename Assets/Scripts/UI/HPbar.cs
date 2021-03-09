using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public Image HpBarImg;
    [SerializeField] Player player;
    private float playerHealth;
    private float HPpercent;

    void OnEnable()
    {
        Player.PlayerHpChange += UpdateHpBar;
    }

    void OnDisable()
    {
        Player.PlayerHpChange -= UpdateHpBar;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.property.health;
        HPpercent = 1.0f;
        HpBarImg.color = Color.Lerp(Color.red, Color.green, HPpercent);

    }

    public void UpdateHpBar(int currentHealth)
    {
        HPpercent = currentHealth / playerHealth;
        HpBarImg.fillAmount = Mathf.Lerp(0.25f, 1, HPpercent);
        HpBarImg.color = Color.Lerp(Color.red, Color.green, HPpercent);
    }
}
