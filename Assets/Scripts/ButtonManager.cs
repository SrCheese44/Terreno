using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{


    public void RetryGame()
    {
        SceneManager.LoadScene(0);
    }

    
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }


}
