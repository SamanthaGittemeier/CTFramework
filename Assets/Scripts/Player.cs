using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _forwardSpeed;

    [SerializeField]
    private GameObject _externalCam;

    void Start()
    {
        _forwardSpeed = 5;
        _moveSpeed = 15;
    }

    void Update()
    {
        MoveShip();
    }

    private void MoveShip()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        transform.Translate(transform.forward * _forwardSpeed * Time.deltaTime);
        Vector3 rotation = new Vector3(vInput, hInput, 0);
        transform.Rotate(rotation * _moveSpeed * Time.deltaTime);
    }
}
