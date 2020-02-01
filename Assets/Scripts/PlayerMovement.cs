using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float horizontalSpeed;

    [SerializeField]
    private float verticalAddSpeed;

    [SerializeField]
    private float jump;

    [SerializeField]
    private float jetPack;
    private float jetPackStart;

    [SerializeField]
    private Image fuelBar;

    [SerializeField]
    private float jetPackConsumption;
   
    public GameObject playerArt;
    
    private float airSpeed;

    private Rigidbody2D rigidBody;
    private bool moving;
    private bool flying;

    private bool grounded;
    private bool piloting = false;
  
    void Start()
    {
        
        jetPackStart = jetPack;
        rigidBody = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        if (!piloting)
        {

            if (Input.GetKey(KeyCode.RightArrow))
            {
                playerArt.transform.rotation = Quaternion.Euler(0, 0, 0);
                rigidBody.velocity = new Vector2(horizontalSpeed, rigidBody.velocity.y);
                moving = true;
                anim.SetBool("Running", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerArt.transform.rotation = Quaternion.Euler(0, 180, 0);
                rigidBody.velocity = new Vector2(-horizontalSpeed, rigidBody.velocity.y);
                moving = true;
                anim.SetBool("Running", true);
            }
            else
            {
                moving = false;
                anim.SetBool("Running", false);
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
                anim.SetBool("Flying", true);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, airSpeed);
            }

            if (flying)
            {
                fuelBar.gameObject.SetActive(true);
                airSpeed += verticalAddSpeed;
                jetPack -= jetPackConsumption;
                UpdateFuelBar();
            }
            else if (!flying)
            {
                
                airSpeed = 0;
                CheckGround();
                if (grounded && jetPack < jetPackStart)
                {
                    fuelBar.gameObject.SetActive(true);
                    jetPack += jetPackConsumption;
                    UpdateFuelBar();
                }
            }

            CheckGround();
            if (grounded)
            {
                anim.SetBool("Flying", false);
                if (jetPack >= jetPackStart)
                {
                    fuelBar.gameObject.SetActive(false);
                }
                
            }
            else
            {
                anim.SetBool("Flying", true);
            }

            flying = false;
            
        }
    }

    private void CheckGround()
    {
        grounded = transform.GetChild(0).GetComponent<GroundChecker>().ground;
    }
    
    private void UpdateFuelBar()
    {
        fuelBar.fillAmount = jetPack / jetPackStart;
    }

    public void SetPiloting(bool state)
    {
        piloting = state;
    }
}
