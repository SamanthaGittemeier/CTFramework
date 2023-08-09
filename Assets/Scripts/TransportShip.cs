using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportShip : MonoBehaviour
{
    [SerializeField]
    private GameObject _endDirector;
    [SerializeField]
    private GameObject _restartButton;

    private void Awake()
    {
        _endDirector = GameObject.Find("EndCutScene");
        _endDirector.SetActive(false);
        _restartButton = GameObject.Find("RestartButton");
        _restartButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _endDirector.SetActive(true);
        }
    }
}
