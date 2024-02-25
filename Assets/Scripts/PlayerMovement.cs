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

    private float deathTimer = 0f;
    public bool deathTimerBegin;
    [SerializeField]
    GameObject crosshair;


    public GameObject spawnPoint;

    public ParticleSystem Explosion;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        deathTimerBegin = false;
    }

    void Update()
    {
        if (!deathTimerBegin)
        {
            transform.position += transform.forward * playerSpeed * Time.deltaTime;

            turn.x += Input.GetAxis("Mouse X") * turnSpeed;
            turn.y += Input.GetAxis("Mouse Y") * turnSpeed;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }


        if (Input.GetKey(KeyCode.W))
        {
            playerSpeed +=  7 * Time.deltaTime;

            if(playerSpeed > maxSpeed) 
            {
                playerSpeed = maxSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerSpeed -= 7 * Time.deltaTime;

            if(playerSpeed < minSpeed)
            {
                playerSpeed = minSpeed;
            }
        }

        if (deathTimerBegin)
        {
            deathTimer += Time.deltaTime;
            Debug.Log(deathTimer);
            if (deathTimer >= 2)
            {
                deathTimer = 0;
                deathTimerBegin = false;
                RespawnPlayer();
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain") || collision.gameObject.tag == "Enemy")
        {
            deathTimerBegin = true;
            rb.isKinematic = true;
            rb.GetComponent<Renderer>().enabled = false;
            crosshair.SetActive(false);

            Explosion.Play();
            Explosion.transform.position = transform.position;

           
        }



    }

    private void RespawnPlayer()
    {
        transform.position = spawnPoint.transform.position;
        transform.rotation = spawnPoint.transform.rotation;
        gameObject.SetActive(true);
        rb.isKinematic = false;
        rb.GetComponent<Renderer>().enabled = true;
        crosshair.SetActive(true);

    }



}
