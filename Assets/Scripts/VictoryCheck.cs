using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryCheck : MonoBehaviour
{
    public GameObject victoryScreen;
    public GameObject player;
    public AudioSource backgroundOst;

    [SerializeField]
    TextMeshProUGUI enemiesLeftLabel;

   
    void Update()
    {
        enemiesLeftLabel.text = transform.childCount.ToString("00") + " left";

        if (transform.childCount == 0 && victoryScreen.activeSelf == false)
        {
            victoryScreen.SetActive(true);
            player.SetActive(false);
            backgroundOst.Stop();
        }
    }
}