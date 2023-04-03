using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private int _gold = 0;

    public int Gold
    { 
        get { return _gold; }
    }
    private int _stageID = 1;

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
    }
    public void LoadScene(int stageID)
    {
        SceneManager.LoadScene(stageID);
    }

    public Text goldTxt;

    public Text stageTxt;
    public Text iceTxt;
    public Text toppingTxt;
    public Text syrupTxt;

    [SerializeField] private float _iceWeight;
    [SerializeField] private Topping.ToppingType _goalToppingType;
    [SerializeField] private Syrup.SyrupType _goalSyrupType;

    private void LateUpdate()
    {
        goldTxt.text = string.Format("{0:n0}", Gold);
        
        stageTxt.text = string.Format($"Stage {_stageID}");
        iceTxt.text = string.Format($"Ice : {_iceWeight}");
        toppingTxt.text = string.Format($"Topping : {_goalToppingType}");
        syrupTxt.text = string.Format($"Syrup : {_goalSyrupType}");
    }
}
