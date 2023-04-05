using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameOver : MonoBehaviour
{
    private PlayerStatus _status;

    void Awake()
    {
        _status = gameObject.GetComponent<PlayerStatus>();
        if (_status != null)
        {
            _status.GameOver -= OnGameOver;
            _status.GameOver += OnGameOver;
        }
    }

    private void OnDestroy()
    {
        if (_status != null)
        {
            _status.GameOver -= OnGameOver;
        }
    }
    private void OnGameOver()
    {
        gameObject.GetComponent<PlayerInput>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        transform.GetChild(0).gameObject.SetActive(false);
        gameObject.GetComponent<Animator>().SetTrigger("PlayerMelt");
    }
}
