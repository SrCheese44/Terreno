using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField]
    public float playerSpeed;
    public Vector2 turn;
    public float turnSpeed = .5f;
    public float minSpeed;
    public float maxSpeed;

    public GameObject spawnPoint;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.position += transform.forward * playerSpeed * Time.deltaTime;

        turn.x += Input.GetAxis("Mouse X") * turnSpeed;
        turn.y += Input.GetAxis("Mouse Y") * turnSpeed;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        if (Input.GetKey(KeyCode.W))
        {
            playerSpeed +=  5 * Time.deltaTime;

            if(playerSpeed > maxSpeed) 
            {
                playerSpeed = maxSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerSpeed -= 5 * Time.deltaTime;

            if(playerSpeed < minSpeed)
            {
                playerSpeed = minSpeed;
            }
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain") || collision.gameObject.tag == "Enemy")
        {
            transform.position = spawnPoint.transform.position;
            transform.rotation = spawnPoint.transform.rotation;
        }

    }




}
