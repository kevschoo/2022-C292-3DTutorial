using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowningObject : MonoBehaviour
{
    float _delayDestruction = 5;
    private float bulletspeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _delayDestruction);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }


}
