using ItemInterface;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

class Goal : Items
{
    [Header("스테이지 클리어 별 효과음")]
    [SerializeField] string sound_Star;

    public int _starNum { get; private set; }
    public event Action _isPlayerOnGoal;
    public bool _isAnimationEnded;
    private void OnEnable()
    {
        _isAnimationEnded = false;
    }
    public override void EffectToPlayer()
    {
        GetComponent<BoxCollider>().enabled = false;
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
            //SoundManager.instance.PlaySoundEffect(sound_Star);
            Debug.Log("★");
        }

        GameManager.Instance.Reward(100, _starNum);
        Debug.Log($"현재 골드 : {GameManager.Instance.Gold}");

        PlayAnimation();
    }
    private void PlayAnimation()
    {
        _isPlayerOnGoal?.Invoke();
    }
}