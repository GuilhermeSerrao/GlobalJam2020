using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipDamage : MonoBehaviour
{
    [SerializeField]
    private float health;
    private float currentHealth;

    [SerializeField]
    private Image healthBar;

    private void Start()
    {
        currentHealth = health;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentHealth = 0;
        }
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("DeathScreen", LoadSceneMode.Single);
        }
    }

    public void dealDamage(float damage)
    {
        if (health > 0)
        {
            currentHealth -= damage;
            UpdateBar();
        }

        if (health <= 0)
        {
            SceneManager.LoadScene("DeathScreen", LoadSceneMode.Single);
        }
        
    }

    private void UpdateBar()
    {
        healthBar.fillAmount = currentHealth / health;
    }
}
