using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{

    [SerializeField]
    private float detectRange;

    private Enemy enemy;

    private RaycastHit2D hit;

    private bool spoted = false;

    private PlayerMovement player;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        enemy = transform.parent.GetComponent<Enemy>();
    }

    void Update()
    {
        Raycast();
        if (hit)
        {
            print(hit.collider.gameObject.name);
            if (hit.collider.gameObject.GetComponent<PlayerMovement>())
            {
                spoted = true;
                

            }
            else
            {
                spoted = false;

            }
        }
        else
        {
            spoted = false;
        }
        enemy.SetChase(spoted);

    }

    private void Raycast()
    {
        var heading = player.transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        hit = Physics2D.Raycast(transform.position, direction, detectRange, 1 << 8 | 1 << 13);
        

    }
}
