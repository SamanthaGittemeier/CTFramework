using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed;
    [SerializeField]
    private float _forwardSpeed;
    [SerializeField]
    private float _defaultForwardSpeed;
    [SerializeField]
    private float _speedChange;
    [SerializeField]
    private float _xGain;
    [SerializeField]
    private float _yGain;
    [SerializeField]
    private float _xChangeAmount;
    [SerializeField]
    private float _yChangeAmount;
    [SerializeField]
    private float _introCutSceneTime;

    [SerializeField]
    private Quaternion _playerRotation;

    [SerializeField]
    private PlayableDirector _introCutSceneDirector;

    void Start()
    {
        _forwardSpeed = _defaultForwardSpeed;
        _introCutSceneDirector = GameObject.Find("IntroCutScene").GetComponent<PlayableDirector>();
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (_introCutSceneDirector.time >= _introCutSceneTime)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _xGain -= _xChangeAmount;
            }

            if (Input.GetKey(KeyCode.S))
            {
                _xGain += _xChangeAmount;
            }

            if (Input.GetKey(KeyCode.D))
            {
                _yGain += _yChangeAmount;
            }

            if (Input.GetKey(KeyCode.A))
            {
                _yGain -= _yChangeAmount;
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
        }

        _playerRotation = Quaternion.Euler(_xGain, _yGain, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, _playerRotation, _rotateSpeed);
        transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);
    }
}
