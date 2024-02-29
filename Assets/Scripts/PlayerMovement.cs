using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField]
    GameObject jetEffect;

    public AudioSource music;

    public GameObject deathScreen;

    [SerializeField]
    AudioSource defeatMusic;

    [SerializeField]
    AudioSource playerBoom;

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

        MouseMovement();   

        AccelerateAndBreak();
       

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
            jetEffect.SetActive(false); 
            
            playerBoom.Play();

            Explosion.Play();
            Explosion.transform.position = transform.position;
            music.Stop();
            

           
        }



    }

    private void RespawnPlayer()
    {
        
        deathScreen.SetActive(true);
        defeatMusic.Play();

        Destroy(gameObject);
        crosshair.SetActive(true);
        jetEffect.SetActive(true);

        Cursor.lockState = CursorLockMode.None;


    }



    private void MouseMovement()
    {
        if (!deathTimerBegin)
        {
            transform.position += transform.forward * playerSpeed * Time.deltaTime;

            turn.x += Input.GetAxis("Mouse X") * turnSpeed;
            turn.y += Input.GetAxis("Mouse Y") * turnSpeed;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
    }



    private void AccelerateAndBreak()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerSpeed += 15 * Time.deltaTime;

            if (playerSpeed > maxSpeed)
            {
                playerSpeed = maxSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerSpeed -= 15 * Time.deltaTime;

            if (playerSpeed < minSpeed)
            {
                playerSpeed = minSpeed;
            }
        }
    }

}
