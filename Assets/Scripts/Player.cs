using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float _mouseSensitivity = 10f;
    [SerializeField] Camera _mainCamera;
    [SerializeField] RunTimeData _runtimedata;
    float _currentTilt = 0f;
    float _moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        if(_runtimedata.CurrentGameplayState == GameplayState.FreeWalk)
        {
            Movement();
        }
        

    }

    void Aim()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * _mouseSensitivity);
        //_mainCamera.transform.Rotate(Vector3.right, mouseY * _mouseSensitivity);

        _currentTilt -= mouseY * _mouseSensitivity;
        _currentTilt = Mathf.Clamp(_currentTilt, -90, 90);

        _mainCamera.transform.localEulerAngles = new Vector3(_currentTilt, 0, 0);
    }

    void Movement()
    {
        Vector3 sideMove = transform.right * Input.GetAxis("Horizontal");
        Vector3 frontBack = transform.forward * Input.GetAxis("Vertical");
        Vector3 movement = sideMove + frontBack;
        GetComponent<CharacterController>().Move(movement * _moveSpeed * Time.deltaTime);
    }
}
