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
    private float _shipYGain;
    [SerializeField]
    private float _shipZGain;
    [SerializeField]
    private float _shipXChangeAmount;
    [SerializeField]
    private float _shipYChangeAmount;
    [SerializeField]
    private float _shipZChangeAmount;

    [SerializeField]
    private GameObject _ship;
    [SerializeField]
    private GameObject _camera;

    [SerializeField]
    private CameraSwitch _camSwitcher;

    [SerializeField]
    private bool _shipMoved;

    [SerializeField]
    private Vector3 _cockpitPOVOffset;

    void Start()
    {
        _forwardSpeed = 3;
        _shipRotateSpeed = 15;
        _ship = GameObject.Find("Ship");
        _camera = GameObject.Find("Cockpit-POV");
        _camSwitcher = GameObject.Find("Camera Switch").GetComponent<CameraSwitch>();
    }

    void Update()
    {
        MoveShipAndCameras();
    }

    private void MoveShipAndCameras()
    {
        _camera.transform.position = transform.position + _cockpitPOVOffset;
        _camera.transform.rotation = transform.rotation;
        if (Input.GetKey(KeyCode.W))
        {
            _shipMoved = true;
            _camSwitcher.InputGivenFromMovement(_shipMoved);
            _shipXGain += _shipXChangeAmount;
            Quaternion shipXRot = Quaternion.Euler(_shipXGain, _shipYGain, _shipZGain);
            transform.rotation = Quaternion.Slerp(transform.rotation, shipXRot, _shipRotateSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _shipMoved = true;
            _camSwitcher.InputGivenFromMovement(_shipMoved);
            _shipXGain -= _shipXChangeAmount;
            Quaternion shipXRot = Quaternion.Euler(_shipXGain, _shipYGain, _shipZGain);
            transform.rotation = Quaternion.Slerp(transform.rotation, shipXRot, _shipRotateSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _shipMoved = true;
            _camSwitcher.InputGivenFromMovement(_shipMoved);
            _shipZGain -= _shipZChangeAmount;
            if (_shipZGain <= -5)
            {
                _shipZGain = -5;
            }
            _shipYGain += _shipYChangeAmount;
            Quaternion shipYRot = Quaternion.Euler(_shipXGain, _shipYGain, _shipZGain);
            transform.rotation = Quaternion.Slerp(transform.rotation, shipYRot, _shipRotateSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _shipMoved = true;
            _camSwitcher.InputGivenFromMovement(_shipMoved);
            _shipZGain += _shipZChangeAmount;
            if (_shipZGain >= 5)
            {
                _shipZGain = 5;
            }
            _shipYGain -= _shipYChangeAmount;
            Quaternion shipYRot = Quaternion.Euler(_shipXGain, _shipYGain, _shipZGain);
            transform.rotation = Quaternion.Slerp(transform.rotation, shipYRot, _shipRotateSpeed);
        }
        transform.Translate(transform.forward * _forwardSpeed * Time.deltaTime);
    }
}
