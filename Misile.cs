using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misile : MonoBehaviour
{
    [SerializeField]
    private float _speed = 15.0f, _rotationSpeed = 1000.0f, _focusDistance = 5.0f;
    private Transform _target;
    private bool _isLookingAtObject = true;
    [SerializeField]
    private GameObject _particlePrefab;

    // Start is called before the first frame update
    void Start()
    {
     
        _target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MissileMovement();
    }

    private void MissileMovement()
    {
      
        Vector3 targetDirection = _target.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _rotationSpeed * Time.deltaTime, 0.0f);
        transform.Translate(Vector3.forward * Time.deltaTime * _speed, Space.Self);

        if (Vector3.Distance(transform.position, _target.position) < _focusDistance)
        {
            _isLookingAtObject = false;
        }
        if (_isLookingAtObject)
        {
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.Damage();
            Destroy(gameObject);
            GameObject explosionPrefab = Instantiate(_particlePrefab, other.transform.position, Quaternion.identity);
            Destroy(explosionPrefab.gameObject, 1f);
            
        }
    }
}
