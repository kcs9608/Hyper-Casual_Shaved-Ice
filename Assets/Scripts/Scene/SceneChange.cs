using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void TouchHome()
    {
        GameManager.Instance.EnterNextStage();
    }
    public void TouchReturn()
    {
        SceneManager.LoadScene(GameManager.Instance._stageID % 5);
    }
}
