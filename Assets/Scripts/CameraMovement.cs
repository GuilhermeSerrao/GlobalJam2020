using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float smallSize;

    [SerializeField]
    private float bigSize;

    [SerializeField]
    private float bigPosX;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform cameraZero;

    public bool flying;

    private Transform player;

    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player && !flying)
        {
            destination = new Vector3(player.transform.position.x, cameraZero.transform.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
        }       
     
    }

    public void ChangeFlying(bool piloting)
    {
        if (piloting)
        {
            flying = true;
            transform.position = new Vector3(bigPosX, 0, -10);
            GetComponent<Camera>().orthographicSize = bigSize;
        }
        else
        {
            flying = false;
            transform.position = cameraZero.transform.position;
            GetComponent<Camera>().orthographicSize = smallSize;
        }
        
    }

}
