using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;

public class Player : MonoBehaviour
{

    float _mouseSensitivity = 10f;
    [SerializeField] Camera _mainCamera;
    [SerializeField] RunTimeData _runtimedata;
    [SerializeField] float _currentTilt = 0f;
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] int _health = 50;
    [SerializeField] GameObject _CurrentThrowingObject;
    [SerializeField] Camera _cam;
    [SerializeField] Transform _firepoint;
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        _CurrentThrowingObject = _runtimedata.CurrentFood;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if(_health <= 0)
        {
            
        }

        _CurrentThrowingObject = _runtimedata.CurrentFood;
        Aim();
        if(_runtimedata.CurrentGameplayState == GameplayState.FreeWalk)
        {
            Movement();
        }
        Shoot();

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
        GetComponent<CharacterController>().Move(new Vector3(0, -9.8f, 0));
    }

    void Shoot()
    {


        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = _cam.ViewportPointToRay(new Vector3(.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            { destination = hit.point; }
            else
            { destination = ray.GetPoint(1000); }

            spawnProj();
        }
    }

    void spawnProj()
    {
        var proj = Instantiate(_CurrentThrowingObject, _firepoint.position, Quaternion.identity) as GameObject;
        proj.GetComponent<Rigidbody>().velocity = (destination - _firepoint.position).normalized * 50f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other);
        }
        if (other.CompareTag("Enemy"))
        {
            this._health -= other.GetComponent<Enemy>().GetDamage();
            Destroy(other);
            
        }
    }

    public int getHealth()
    {
        return _health;
    }
}



