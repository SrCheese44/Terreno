using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsBehaviour : MonoBehaviour
{
    [SerializeField] GameObject randomSpawn1;
    [SerializeField] GameObject randomSpawn2;




    private void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * 55);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            

            float randomX = Random.Range(randomSpawn1.transform.position.x, randomSpawn2.transform.position.x);
            float randomY = Random.Range(randomSpawn1.transform.position.y, randomSpawn2.transform.position.y);
            float randomZ = Random.Range(randomSpawn1.transform.position.z, randomSpawn2.transform.position.z);

            Vector3 randomRange = new Vector3(randomX, randomY, randomZ);
            transform.position = randomRange;

            

        }
    }
}
