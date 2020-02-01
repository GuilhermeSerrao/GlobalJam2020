using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform cameraZero;

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
        destination = new Vector3(player.transform.position.x, transform.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime );
     
    }
}
