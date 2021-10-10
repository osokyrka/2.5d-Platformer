using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRotator : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f, _rotateSpeed = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }
}
