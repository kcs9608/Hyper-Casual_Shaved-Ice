using ItemInterface;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
class Goal : Items
{
    public AudioSource stageClearSfx;
    [SerializeField] private GameObject stageClearUI;
    public void LoadStageClearUI()
    {
        stageClearUI.SetActive(true);
    }
    public int _starNum { get; private set; }
    public event Action _isPlayerOnGoal;
    [SerializeField] private Sprite clearStar;
    [SerializeField] private GameObject[] stars;
    private Image[] currentStar;

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
            _player.GetComponent<PlayerGameOver>().LoadGameOverUI();
            _player.GetComponent<PlayerInput>().enabled = false;
            _player.GetComponent<PlayerMovement>().enabled = false;
            return;
        }
        for (int i = 0; i < _starNum; ++i)
        {
            ChangeImage(i);
            Debug.Log("¡Ú");
        }
        GameManager.Instance.Reward(100, _starNum);
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