using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float shipDamage;

    [SerializeField]
    private float playerDamage;

    [SerializeField]
    private HullDamage damageToSpawn;

    [SerializeField]
    private PlayerMovement player;    

    private ShipDamage ship;

    private bool chase;

    [SerializeField]
    private float startTimer;
    private float timer;

    [SerializeField]
    private float speed;

    private void Start()
    {
        timer = startTimer;
        player = FindObjectOfType<PlayerMovement>();
        ship = FindObjectOfType<ShipDamage>();
    }
    private void Update()
    {

        if (!chase)
        {
            if (startTimer > 0)
            {
                startTimer -= Time.deltaTime;
            }
            else if (startTimer <= 0)
            {
                Instantiate(damageToSpawn, transform.position, Quaternion.identity);
                ship.dealDamage(shipDamage);
                startTimer = timer;
            }
        }
        else
        {
            transform.right = transform.position - player.transform.position ;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealth>())
        {
            collision.GetComponent<PlayerHealth>().DealDamage(playerDamage);
        }
    }
    public void SetChase(bool state)
    {
        chase = state;
    }
}
