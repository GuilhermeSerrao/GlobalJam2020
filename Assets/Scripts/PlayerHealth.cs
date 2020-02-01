using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    private Image healthbar;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private float imuneTime;
    private float time;
    private bool canTakeDamage = true;

    private float currentHealth;

    private void Start()
    {
        time = imuneTime;
        healthbar.gameObject.SetActive(false);
        currentHealth = maxHealth;
    }
    private void Update()
    {      

        if (time > 0 && !canTakeDamage)
        {
            time -= Time.deltaTime;
        }
        else if(time <= 0)
        {
            canTakeDamage = true;
        }

        if (currentHealth < maxHealth)
        {
            healthbar.gameObject.SetActive(true);
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void UpdateHealthBar()
    {
        healthbar.fillAmount = currentHealth / maxHealth;
    }

    public void DealDamage(float damage)
    {
        if (canTakeDamage)
        {
            canTakeDamage = false;
            currentHealth -= damage;
            UpdateHealthBar();
            
        }       
        
    }
}
