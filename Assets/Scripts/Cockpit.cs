using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockpit : MonoBehaviour
{
    private CameraMovement camera;
    private bool piloting = false;
    private bool hasPlayer;
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<CameraMovement>();
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                piloting = !piloting;
                camera.ChangeFlying(piloting);
                player.SetPiloting(piloting);
            }
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
