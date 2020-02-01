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

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentHealth -= 0.5f;
            UpdateHealthBar();
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
}
