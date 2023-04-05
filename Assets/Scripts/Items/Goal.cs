using ItemInterface;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

class Goal : Items
{
    [SerializeField] private AudioSource stageClearSfx;

    private int _starNum;
    public event Action _isPlayerOnGoal;

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
            Debug.Log("¡Ú");
        }

        GameManager.Instance.Reward(100, _starNum);
        Debug.Log($"ÇöÀç °ñµå : {GameManager.Instance.Gold}");

        PlayAnimation();
    }
    private void PlayAnimation()
    {
        _isPlayerOnGoal?.Invoke();
    }
}