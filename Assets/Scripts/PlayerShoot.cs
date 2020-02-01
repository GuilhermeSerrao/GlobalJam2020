using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private float fireRate;

    private float shootTimer;

    private bool canShoot = true;

    private GameObject playerArt;

    private void Start()
    {
        shootTimer = fireRate;
        playerArt = FindObjectOfType<PlayerMovement>().playerArt;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.X) && canShoot)
        {
            var newBullet = Instantiate(bullet, shootPoint.position, playerArt.transform.rotation);
            newBullet.speed = bulletSpeed;
            canShoot = false;
        }

        if (shootTimer > 0 && !canShoot)
        {
            shootTimer -= Time.deltaTime;
        }
        else
        {
            canShoot = true;
            shootTimer = fireRate;
        }
        

        
    }
}
