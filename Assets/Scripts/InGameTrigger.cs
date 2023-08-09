using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InGameTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _transportShip;
    [SerializeField]
    private GameObject _inGameDirector;

    [SerializeField]
    private bool _played;

    void Start()
    {
        _transportShip = GameObject.Find("TransportShip");
        _transportShip.SetActive(false);
        _inGameDirector = GameObject.Find("In-GameCutScene");
        _inGameDirector.SetActive(false);
        _played = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _played == false)
        {
            _inGameDirector.SetActive(true);
            _played = true;
        }
    }
}
