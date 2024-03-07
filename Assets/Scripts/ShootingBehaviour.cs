using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject balaPrefab;
   

    public float bulletSpeed = 150f;

    //La variable shootCooldown se debe ajustar en los dos empty hijos del jugador "CannonL" y "CannonR"
    float shootCooldownTimer;
    public float shootCooldown = 0.5f;
    public float reloadTime = 2.0f;
    public float manualReloadTime = 1f;
   
    public int bullets = 15;

    [SerializeField]
    TextMeshProUGUI bulletsLeftLabel;


    [SerializeField]
    AudioSource bulletSound;
    
    void Start()
    {
        ObjectPool.PreLoad(balaPrefab, 10);

       
    }

   
    void Update()
    {
        if(bullets != 0)
        {
            FireFunction();

        }

        reloadFunction();


        bulletsLeftCanva();
    }

    IEnumerator Recicle(GameObject prefab, GameObject copiaPrefab, float time) 
    {
        yield return new WaitForSeconds(time);
        ObjectPool.RecicleObject(prefab, copiaPrefab);
    }



    private void FireFunction()
    {
        
           shootCooldownTimer -= Time.deltaTime;
            if (shootCooldownTimer < 0 && bullets != 0)
            {
          
                if (Input.GetButtonUp("Fire1"))
                {
                     bulletSound.Play();
                     GameObject bala = ObjectPool.GetObject(balaPrefab); //Hacemos que el gameobject sea igual al de la funcion del object pool

                     Rigidbody rb_bala = bala.GetComponent<Rigidbody>();
                     bala.transform.position = transform.position; 

                     rb_bala.velocity = transform.forward * bulletSpeed;
                     StartCoroutine(Recicle(balaPrefab, bala, 2.0f)); // Reutilizamos la bala

                     shootCooldownTimer = shootCooldown;

                     bullets--;



                }
          
            }


    }

   //Tiempos de recarga en base a si son manual o por falta de balas
    private void reloadFunction()
    {
         if (bullets == 0)
         {
            reloadTime -= Time.deltaTime;

            if (reloadTime < 0)
            {
                bullets = 15;
                reloadTime = 2.0f;
            }

         }

        if (Input.GetKeyDown(KeyCode.R))
        {
            bullets = 0;

            reloadTime = manualReloadTime;

            if(manualReloadTime < 0)
            {
                bullets = 15;
            }

           
        }


    }
      
   private void bulletsLeftCanva()
    {
        //El texto que muestra por pantalla al jugador la cantidad de balas que le quedan, si llega a 0, pone recargando
        bulletsLeftLabel.text = bullets.ToString("0") + " /15";

        if (bullets == 0)
        {

            bulletsLeftLabel.text = bullets.ToString("Recargando");
        }
    }


}