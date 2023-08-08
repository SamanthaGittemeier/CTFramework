using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _povCockpit;
    [SerializeField]
    private CinemachineVirtualCamera _external3rdPerson;
    [SerializeField]
    private CinemachineBlendListCamera _cinematicShot;

    [SerializeField]
    private GameObject _ship;

    [SerializeField]
    private float _inputTimer;
    [SerializeField]
    private float _idleTimer;

    [SerializeField]
    private int _currentCam;

    [SerializeField]
    private bool _inputGiven;

    [SerializeField]
    private Vector3 _previousMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        _povCockpit = GameObject.Find("Cockpit-POV").GetComponent<CinemachineVirtualCamera>();
        _external3rdPerson = GameObject.Find("External-3rdPersonFollow").GetComponent<CinemachineVirtualCamera>();
        _external3rdPerson.Priority = 10;
        _povCockpit.Priority = 11;
        _ship = GameObject.Find("Ship");
        _cinematicShot = GameObject.Find("Cinematic Shot").GetComponent<CinemachineBlendListCamera>();
        _cinematicShot.Priority = 9;
        _idleTimer = 5;
        _previousMousePosition = Input.mousePosition;
        _ship.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCameras();
        CheckForInput();
        InitiateCinematicShot();
    }

    private void SwitchCameras()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_external3rdPerson.Priority == 11)
            {
                _inputGiven = true;
                _inputTimer = 0;
                _ship.SetActive(false);
                _currentCam = 0;
                _povCockpit.Priority = 11;
                _external3rdPerson.Priority = 10;
                _cinematicShot.Priority = 9;
            }
            else if (_povCockpit.Priority == 11)
            {
                _inputGiven = true;
                _inputTimer = 0;
                _ship.SetActive(true);
                _currentCam = 1;
                _external3rdPerson.Priority = 11;
                _povCockpit.Priority = 10;
                _cinematicShot.Priority = 9;
            }
        }
    }

    private void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.T) || Input.GetKey(KeyCode.G) || Input.mousePosition != _previousMousePosition)
        {
            _inputGiven = true;
            _inputTimer = 0;
            _previousMousePosition = Input.mousePosition;
            _cinematicShot.Priority = 9;
            if (_currentCam == 0)
            {
                _povCockpit.Priority = 11;
                _external3rdPerson.Priority = 10;
                _ship.SetActive(false);
            }
            else if (_currentCam == 1)
            {
                _external3rdPerson.Priority = 11;
                _povCockpit.Priority = 10;
                _ship.SetActive(true);
            }
        }
    }

    private void InitiateCinematicShot()
    {
        if (Input.GetKeyUp(KeyCode.R) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.T) || Input.GetKeyUp(KeyCode.G) || Input.mousePosition == _previousMousePosition)
        {
            _inputGiven = false;
            _inputTimer += Time.deltaTime;
            if (_inputTimer >= _idleTimer && _inputGiven == false)
            {
                _cinematicShot.Priority = 12;
                _ship.SetActive(true);
            }
        }
    }
}
