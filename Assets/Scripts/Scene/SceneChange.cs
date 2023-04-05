using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void ToShop()
    {
        SceneManager.LoadScene(1);
    }

    public void MainToSetting()
    {
        SceneManager.LoadScene(2);
    }

    public void ToGame()
    {
        SceneManager.LoadScene(3);
    }

    //public void ToNextStage()
    //{
    //    SceneManager.LoadScene(4);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
