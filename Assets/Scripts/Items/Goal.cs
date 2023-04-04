using ItemInterface;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

class Goal : Items
{
    [Header("�������� Ŭ���� �� ȿ����")]
    [SerializeField] string sound_Star;

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
            SceneManager.LoadScene("SampleScene");
            return;
        }

        for(int i = 0; i < _starNum; ++i)
        {
            SoundManager.instance.PlaySoundEffect(sound_Star);
            Debug.Log("��");
        }

        GameManager.Instance.Reward(100, _starNum);
        Debug.Log($"���� ��� : {GameManager.Instance.Gold}");

        PlayAnimation();
    }
    private void PlayAnimation()
    {
        _isPlayerOnGoal?.Invoke();
    }
}