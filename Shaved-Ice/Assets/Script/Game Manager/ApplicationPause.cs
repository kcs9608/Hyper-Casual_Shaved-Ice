using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationPause : MonoBehaviour
{
    private bool isApplicationPaused;

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            isApplicationPaused = true;
            Debug.Log("게임 일시정지");
        }
        else
        {
            if (isApplicationPaused)
            {
                isApplicationPaused = false;
                Debug.Log("게임 재개");
            }
        }
    }
}
