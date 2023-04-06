using ItemInterface;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
class Goal : Items
{
    [SerializeField] private AudioSource stageClearSfx;
    [SerializeField] private GameObject stageClearUI;
    [SerializeField] private GameObject gameOverUI;
    public void LoadStageClearUI()
    {
        stageClearUI.SetActive(true);
    }
    public void LoadGameOverUI()
    {
        gameOverUI.SetActive(true);
    }
    public int _starNum { get; private set; }
    public event Action _isPlayerOnGoal;
    [SerializeField] private Sprite clearStar; // �ٲ� �̹��� ���� �ִ� ��
    [SerializeField] private GameObject[] stars;
    private Image[] currentStar; // ���� �̹��� ���� ���� ��

    private void Start()
    {
        currentStar = new Image[stars.Length];

        for(int i = 0; i < stars.Length; ++i)
        {
            currentStar[i] = stars[i].GetComponent<Image>();
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
            ChangeImage(i);
            Debug.Log("��");
        }
        GameManager.Instance.Reward(100, _starNum);
        Debug.Log($"���� ��� : {GameManager.Instance.Gold}");
        PlayAnimation();
    }
    public void ChangeImage(int index)
    {
        currentStar[index].sprite = clearStar;
    }
    private void PlayAnimation()
    {
        _isPlayerOnGoal?.Invoke();
    }
}