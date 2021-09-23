using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA, _pointB;
    [SerializeField]
    private float _speed;
    private bool _switching = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlatformMovement();
    }

    void PlatformMovement()
    {
        if (_switching == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.deltaTime);
        }
        else if (_switching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _speed * Time.deltaTime);
        }
        if (transform.position == _pointB.position)
        {
            _switching = true;
        }
        else if (transform.position == _pointA.position)
        {
            _switching = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }
}
