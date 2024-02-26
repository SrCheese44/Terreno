using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    public int hitsToDie;

    [SerializeField]
    AudioSource enemyBoom;

    public ParticleSystem Explosion;

    public void ReceiveHit()
    {
        hitsToDie--;
        if (hitsToDie == 0)
        {
            Destroy(gameObject);

            Explosion.Play();
            Explosion.transform.position = transform.position;
            enemyBoom.Play();
        }
    }
}
