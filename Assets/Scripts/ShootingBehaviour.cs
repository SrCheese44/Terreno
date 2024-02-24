using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject balaPrefab;

    public float bulletSpeed = 150f;
    Vector3 Force;

    
    void Start()
    {
        ObjectPool.PreLoad(balaPrefab, 10);
        Force = Vector3.forward * bulletSpeed;
    }

   
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject bala = ObjectPool.GetObject(balaPrefab); //Hacemos que el gameobject sea igual al de la funcion del object pool

            Rigidbody rb_bala = bala.GetComponent<Rigidbody>();
            bala.transform.position = transform.position; // La bala sale donde el cañon
            rb_bala.velocity = transform.forward * bulletSpeed;
            StartCoroutine(Recicle(balaPrefab, bala, 2.0f)); // Reutilizamos la bala
        }
    }

    IEnumerator Recicle(GameObject prefab, GameObject copiaPrefab, float time) 
    {
        yield return new WaitForSeconds(time);
        ObjectPool.RecicleObject(prefab, copiaPrefab);
    }
}