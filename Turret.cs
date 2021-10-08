using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject _turretBullet;
    [SerializeField]
    private float _canFire = -10.0f, _fireRate = 3.0f;

    // Update is called once per frame
    void Update()
    {
        TurretFire();
    }

    private void TurretFire()
    {
        if(Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_turretBullet, transform.position, Quaternion.identity);
        }
    }
}
