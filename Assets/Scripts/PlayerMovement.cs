using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float horizontalSpeed;

    [SerializeField]
    private float verticalAddSpeed;

    
    private float airSpeed;

    private Rigidbody2D rigidBody;
    private bool moving;
    private bool flying;

    private bool grounded;
   

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {

        grounded = transform.GetChild(0).GetComponent<GroundChecker>().ground;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.velocity = new Vector2(horizontalSpeed, rigidBody.velocity.y);
            moving = true;
           // transform.rotation =
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.velocity = new Vector2(-horizontalSpeed, rigidBody.velocity.y);
            moving = true;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            flying = true;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, airSpeed);
        }

        if (flying)
        {
            airSpeed += verticalAddSpeed;
        }
        else if (!flying)
        {
            airSpeed = 0;
        }

        /* else if (!moving)
         {
             rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
         }*/

        flying = false;
        moving = false;

        
        
    }

}
