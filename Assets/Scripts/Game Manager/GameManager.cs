using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Setup();
            }
            return instance;
        }
    }
    public int _gold { get; private set; } = 0;

    public int Gold
    { 
        get { return _gold; }
    }

    public int _stageID { get; private set; } = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }
        Application.targetFrameRate = 30;
        Time.timeScale = 3;
    }

    private static void Setup()
    {
        instance = FindObjectOfType<GameManager>();

        if(instance == null)
        {
            GameObject gameObject = new GameObject();
            gameObject.name = "GameManager";
            instance = gameObject.AddComponent<GameManager>();
            DontDestroyOnLoad(gameObject);
        }
    }
    public void Reward(int rewardGold, int starNum)
    {
        _gold += rewardGold * starNum;
    }

    public void Buy(int price)
    {
        _gold -= price;
    }
    public void EnterNextStage()
    {
        ++_stageID;
        SceneManager.LoadScene(_stageID % 5);
    }
    public void LoadScene(int stageID)
    {
        SceneManager.LoadScene(stageID);
    }
}
