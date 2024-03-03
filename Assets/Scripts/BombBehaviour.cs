using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    [SerializeField] AudioSource bombFalling;
    [SerializeField] AudioSource bomb;  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Terrain")
        {
            
            this.gameObject.SetActive(false);

        }
    }
}
