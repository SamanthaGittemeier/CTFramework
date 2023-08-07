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
    private float _shipXGain;
    [SerializeField]
    private float _camXGain;
    [SerializeField]
    private float _shipYGain;
    [SerializeField]
    private float _camYGain;
    [SerializeField]
    private float _shipZGain;
    [SerializeField]
    private float _camZGain;
    [SerializeField]
    private float _shipXChangeAmount;
    [SerializeField]
    private float _shipYChangeAmount;
    [SerializeField]
    private float _shipZChangeAmount;

    [SerializeField]
    private GameObject _cockpitCam;

    [SerializeField]
    private Vector3 _cockpitCamOffset;
    [SerializeField]
    private Vector3 lookWithShip;

    void Start()
    {
        _forwardSpeed = 3;
        _shipRotateSpeed = 15;
        _cockpitCam = GameObject.Find("Cockpit-POV");
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
            _shipZGain -= _shipZChangeAmount;
            if (_shipZGain <= -5)
            {
                _shipZGain = -5;
            }
            _shipYGain += _shipYChangeAmount;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _shipZGain += _shipZChangeAmount;
            if (_shipZGain >= 5)
            {
                _shipZGain = 5;
            }
            _shipYGain -= _shipYChangeAmount;
        }
        Quaternion shipRot = Quaternion.Euler(_shipXGain, _shipYGain, _shipZGain);
        transform.rotation = Quaternion.Slerp(transform.rotation, shipRot, _shipRotateSpeed);
        transform.Translate(transform.forward * _forwardSpeed * Time.deltaTime);
        _cockpitCam.transform.Translate(transform.forward * _forwardSpeed * Time.deltaTime);
    }
}
