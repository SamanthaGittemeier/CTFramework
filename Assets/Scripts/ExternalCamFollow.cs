using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalCamFollow : MonoBehaviour
{
    [SerializeField]
    private float _forwardSpeed;
    [SerializeField]
    private float _moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _forwardSpeed = 5;
        _moveSpeed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        transform.Translate(transform.forward * _forwardSpeed * Time.deltaTime);
        Vector3 rotation = new Vector3(vInput, hInput, 0);
        transform.Rotate(-rotation * _moveSpeed * Time.deltaTime);
    }
}
