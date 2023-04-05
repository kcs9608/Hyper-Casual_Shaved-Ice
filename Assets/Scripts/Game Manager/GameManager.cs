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
    public int _gold { get; private set; } = 0;

    public int Gold
    { 
        get { return _gold; }
    }

    public int _stageID { get; private set; } = 1;

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

    public string goldTxt;
    public string stageTxt;
    public string iceTxt;
    public string toppingTxt;
    public string syrupTxt;

    [SerializeField] private float _iceWeight;
    [SerializeField] private Topping.ToppingType _goalToppingType;
    [SerializeField] private Syrup.SyrupType _goalSyrupType;

    private void LateUpdate()
    {
        goldTxt = string.Format("{0:n0}", Gold);
        
        stageTxt = string.Format($"Stage {_stageID}");
        iceTxt = string.Format($"Ice : {_iceWeight}");
        toppingTxt = string.Format($"Topping : {_goalToppingType}");
        syrupTxt = string.Format($"Syrup : {_goalSyrupType}");
    }
}
