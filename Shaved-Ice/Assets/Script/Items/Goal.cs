using ItemInterface;
using UnityEngine;
using UnityEngine.SceneManagement;

class Goal : Items
{
    private int _starNum;
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
            Debug.Log("¡Ú");
        }

        GameManager.Instance.Reward(100, _starNum);
        Debug.Log($"ÇöÀç °ñµå : {GameManager.Instance.Gold}");
        SceneManager.LoadScene("SampleScene");

        gameObject.SetActive(false);
    }
}