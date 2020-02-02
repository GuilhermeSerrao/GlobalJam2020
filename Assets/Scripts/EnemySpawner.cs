using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private Enemy enemy;

    [SerializeField]
    private float startTimer;
    private float timer;

    private bool inRoom;

    // Start is called before the first frame update
    void Start()
    {
        timer = startTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if(timer <= 0)
        {
            inRoom = false;
            timer = startTimer;
            transform.position = new Vector2(Random.Range(-70, 62), Random.Range(-19, 27));            
            inRoom = Physics2D.OverlapPoint(transform.position, 1 << 15);
            print(inRoom);
            if (inRoom)
            {
                SpawnEnemy();                
            }
            
        }
        
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.Euler(0,0,Random.Range(0,180)));        
    } 


}
