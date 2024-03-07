using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;

    public HealthBehaviour health;

    [SerializeField]
    AudioSource enemyBoom;

    public float rotateSpeed = 5.0f;

    public ParticleSystem Explosion;
    void Start()
    {
        targetPoint = 0;   
    }

    void Update()
    {

        WaypointManeuver();

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
            health.ReceiveHit();
 
        }

    }


    private void WaypointManeuver()
    {
        Transform waypoint = patrolPoints[targetPoint];
        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

        Vector3 waypointPosition = (patrolPoints[targetPoint].position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(waypointPosition);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }



}

