using ItemInterface;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
class Goal : Items
{
    [SerializeField] private AudioSource stageClearSfx;
    [SerializeField] private GameObject stageClearPanel;
    public void LoadStageClearUI()
    {
        stageClearPanel.SetActive(true);
    }
    public int _starNum { get; private set; }
    public event Action _isPlayerOnGoal;
    [SerializeField] private Sprite[] clearStar; // 바꿀 이미지 색깔 있는 별
    [SerializeField] private GameObject[] stars;
    private Image[] currentStar; // 현재 이미지 색깔 없는 별
    private void Start()
    {
        for(int i = 0; i <stars.Length; ++i)
        {
            //currentStar[i] = stars[i].GetComponent<Image>();
        }
    }
    public override void EffectToPlayer()
    {
        _starNum = 0;
        foreach (bool satisfiedCondition in _conditions._isSatisfied)
        {
            if (satisfiedCondition)
            {
                ++_starNum;
            }
        }
        if (_starNum == 0)
        {
            SceneManager.LoadScene("gameSample");
            return;
        }
        for (int i = 0; i < _starNum; ++i)
        {
            stageClearSfx.Play();
            //ChangeImage(i);
            Debug.Log("★");
        }
        GameManager.Instance.Reward(100, _starNum);
        Debug.Log($"현재 골드 : {GameManager.Instance.Gold}");
        PlayAnimation();
    }
    public void ChangeImage(int index)
    {
        //currentStar[index].sprite = clearStar[index];
    }
    private void PlayAnimation()
    {
        _isPlayerOnGoal?.Invoke();
    }
}