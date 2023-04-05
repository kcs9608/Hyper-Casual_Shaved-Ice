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

    private int _starNum;
    public event Action _isPlayerOnGoal;

    public Sprite[] clearStar; // �ٲ� �̹��� ���� �ִ� ��
    Image[] currentStar; // ���� �̹��� ���� ���� ��

    private void Start()
    {
        currentStar = GetComponent<Image[]>();
    }

    public override void EffectToPlayer()
    {
        _starNum = 0;
        foreach (bool satisfiedCondition in _conditions._isSatisfied)
        {
            if(satisfiedCondition)
            {
                ++_starNum;
            }
        }

        if(_starNum == 0)
        {
            SceneManager.LoadScene("gameSample");
            return;
        }

        for(int i = 0; i < _starNum; ++i)
        {
            stageClearSfx.Play();
            ChangeImage(_starNum);
            Debug.Log("��");
        }

        GameManager.Instance.Reward(100, _starNum);
        Debug.Log($"���� ��� : {GameManager.Instance.Gold}");

        PlayAnimation();
    }

    public void ChangeImage(int index)
    {
        currentStar[index].sprite = clearStar[index];
    }

    private void PlayAnimation()
    {
        _isPlayerOnGoal?.Invoke();
    }
}