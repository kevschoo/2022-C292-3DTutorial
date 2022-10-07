using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] RunTimeData _runtimedata;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _target = null;
    [SerializeField] int _sight = 15;
    [SerializeField] int _health = 20;
    [SerializeField] int _damage = 5;
    [SerializeField] float _moveSpeed = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if(_target == null)
        {
            try
            {
                _target = GameObject.FindGameObjectWithTag("Player");
                _target = FindObjectOfType<Villager>().gameObject;
                
            }
            catch
            {

            }
        }
        if (_health <= 0)
        {
            _runtimedata.CurrentCash += 10;
            Destroy(this.gameObject);
        }
        if(_target != null)
        {
            transform.LookAt(_target.transform);
            Movement(_target.transform);
        }
    }

    public int GetDamage()
    {
        return this._damage;
    }
    void Movement(Transform target)
    {

        this.transform.position += transform.forward * _moveSpeed* Time.deltaTime;
        
        
        if(Vector3.Distance(transform.position, target.position) < _sight)
        {
            _moveSpeed = 3f;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            this._health -= _runtimedata.CurrentFoodDamage;
            Destroy(other);
            
        }
        
    }
}
