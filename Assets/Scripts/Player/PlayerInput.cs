using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    [Range(9f, 10f)]
    private float speed;
    public float _horizontal { get; private set; }
    public float _vertical { get; private set; }

    Vector3 moveVector;

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        moveVector = new Vector3(_horizontal, 0f, _vertical);

        transform.position += moveVector * (speed * Time.deltaTime);
    }
}
