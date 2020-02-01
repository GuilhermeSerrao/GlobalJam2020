using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float horizontalSpeed;

    [SerializeField]
    private float verticalAddSpeed;

    [SerializeField]
    private float jump;

    [SerializeField]
    private float jetPack;
    private float JetPackStart;

    [SerializeField]
    private float jetPackConsumption;

   
    public GameObject playerArt;

    
    private float airSpeed;

    private Rigidbody2D rigidBody;
    private bool moving;
    private bool flying;

    private bool grounded;
   

    // Start is called before the first frame update
    void Start()
    {
        JetPackStart = jetPack;
        rigidBody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {      

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerArt.transform.rotation = Quaternion.Euler(0, 180, 0);
            rigidBody.velocity = new Vector2(horizontalSpeed, rigidBody.velocity.y);
            moving = true;
           
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerArt.transform.rotation = Quaternion.Euler(0, 0, 0);
            rigidBody.velocity = new Vector2(-horizontalSpeed, rigidBody.velocity.y);
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (!moving)
        {
            CheckGround();

            if (grounded)
            {
                rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
                           
            }            
            
        }
        CheckGround();

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            CheckGround();
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump);            
        }

        if (Input.GetKey(KeyCode.UpArrow) && jetPack > 0)   
        {                    
            flying = true;            
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, airSpeed);
        }

        if (flying)
        {
            airSpeed += verticalAddSpeed;
            jetPack -= jetPackConsumption;
        }
        else if (!flying)
        {

            airSpeed = 0;
            CheckGround();
            if (grounded && jetPack < JetPackStart)
            {
              jetPack += jetPackConsumption;                
            }
        }

        flying = false;    
    }

    private void CheckGround()
    {
        grounded = transform.GetChild(0).GetComponent<GroundChecker>().ground;
    }
    
}
