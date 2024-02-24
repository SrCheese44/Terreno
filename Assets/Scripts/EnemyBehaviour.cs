using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;

    void Start()
    {
        targetPoint = 0;   
    }

    void Update()
    {
        Transform waypoint = patrolPoints[targetPoint];
        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
        transform.LookAt(waypoint);
    }



    void increaseTargetInt()
    {
        targetPoint++;
        if(targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);

        }



    }


}

