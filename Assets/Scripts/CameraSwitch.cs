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
    private GameObject _ship;

    // Start is called before the first frame update
    void Start()
    {
        _povCockpit = GameObject.Find("Cockpit-POV").GetComponent<CinemachineVirtualCamera>();
        _external3rdPerson = GameObject.Find("External-3rdPersonFollow").GetComponent<CinemachineVirtualCamera>();
        _external3rdPerson.Priority = 10;
        _povCockpit.Priority = 11;
        _ship = GameObject.Find("Ship");
        _ship.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCameras();
    }

    private void SwitchCameras()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_external3rdPerson.Priority == 11)
            {
                _ship.SetActive(false);
                _povCockpit.Priority = 11;
                _external3rdPerson.Priority = 10;
            }
            else if (_povCockpit.Priority == 11)
            {
                _ship.SetActive(true);
                _external3rdPerson.Priority = 11;
                _povCockpit.Priority = 10;
            }
        }
    }
}
