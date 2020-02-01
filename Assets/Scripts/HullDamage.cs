using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullDamage : MonoBehaviour
{
    [SerializeField]
    private float damageOverTime;

    [SerializeField]
    private float repairTime;

    [SerializeField]
    private float repairSpeed;

    private ShipDamage ship;

    private float timer = 1;
    private float startTimer;

    private bool hasPlayer;

    // Start is called before the first frame update
    void Start()
    {
        startTimer = timer;
        ship = FindObjectOfType<ShipDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer > 0)
        {
            startTimer -= Time.deltaTime;
        }
        else if (startTimer <= 0)
        {
            ship.dealDamage(damageOverTime);
            startTimer = timer;
        }

        if (hasPlayer)
        {
            if (Input.GetKey(KeyCode.C))
            {
                repairTime -= repairSpeed;
            }
        }

        if (repairTime <= 0)
        {
            Destroy(gameObject);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            hasPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            hasPlayer = false;
        }
    }
}
