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
            Debug.Log("���� �Ͻ�����");
        }
        else
        {
            if (isApplicationPaused)
            {
                isApplicationPaused = false;
                Debug.Log("���� �簳");
            }
        }
    }
}
