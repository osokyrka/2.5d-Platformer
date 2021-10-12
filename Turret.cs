using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject _turretBullet;
    [SerializeField]
    private float _canFire = -10.0f, _fireRate = 3.0f;
    [SerializeField]
    private bool _isBoss;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _distanceToTarget = 20.0f;
    [SerializeField]
    private float _bossFireRate = 2.0f;

    // Update is called once per frame
    void Update()
    {
        TurretFire();
    }

    private void TurretFire()
    {
        if(Time.time > _canFire && !_isBoss)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_turretBullet, transform.position, Quaternion.identity);
        }
        else if(Time.time > _canFire && _isBoss)
        {
            float distanceToTarget = Vector3.Distance(_target.position, transform.position);
            if(distanceToTarget < _distanceToTarget)
            {
                _canFire = Time.time + _fireRate / _bossFireRate;
                GameObject missile = Instantiate(_turretBullet, transform.position, Quaternion.identity);
                Destroy(missile, 3f);
            }

        }
    }
}
