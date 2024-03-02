using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBombBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject bombPrefab;

    public float m_bombTimer = 4f;
    public bool canShoot = true;

    private void Start()
    {
        ObjectPool.PreLoad(bombPrefab, 5);
    }


    private void Update()
    {
        if (Input.GetButtonUp("Fire2") && canShoot)
        {
            canShoot = false;

            GameObject bomb = ObjectPool.GetObject(bombPrefab);

            Rigidbody rb_bomb = bomb.GetComponent<Rigidbody>();
            bomb.transform.position = transform.position;

            bomb.GetComponent<Rigidbody>().velocity = Vector3.forward; 

            StartCoroutine(Recicle(bombPrefab, bomb, 2.0f));

            StartCoroutine(bombTimer(m_bombTimer));
        }
    }

    IEnumerator Recicle(GameObject prefab, GameObject copiaPrefab, float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPool.RecicleObject(prefab, copiaPrefab);
    }



    IEnumerator bombTimer(float time)
    {
        yield return new WaitForSeconds(time);
        canShoot = true;
    }
}
