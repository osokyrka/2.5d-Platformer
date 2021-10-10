using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 4.0f;
    private Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_target);
    }
}
