using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _shipRotateSpeed;
    [SerializeField]
    private float _forwardSpeed;
    [SerializeField]
    private float _defaultForwardSpeed;
    [SerializeField]
    private float _speedChange;
    [SerializeField]
    private float _shipXGain;
    [SerializeField]
    private float _shipYGain;
    [SerializeField]
    private float _shipXChangeAmount;
    [SerializeField]
    private float _shipYChangeAmount;

    [SerializeField]
    private Quaternion _shipRot;

    void Start()
    {
        _forwardSpeed = _defaultForwardSpeed;
    }

    void Update()
    {
        MoveShipAndCameras();
    }

    private void MoveShipAndCameras()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _shipXGain -= _shipXChangeAmount;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _shipXGain += _shipXChangeAmount;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _shipYGain += _shipYChangeAmount;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _shipYGain -= _shipYChangeAmount;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            _forwardSpeed += _speedChange;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _forwardSpeed -= _speedChange;
        }

        if (Input.GetKeyUp(KeyCode.T) || Input.GetKeyUp(KeyCode.G))
        {
            _forwardSpeed = _defaultForwardSpeed;
        }

        _shipRot = Quaternion.Euler(_shipXGain, _shipYGain, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, _shipRot, _shipRotateSpeed);
        transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);
    }
}
