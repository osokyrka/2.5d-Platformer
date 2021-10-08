using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletZ : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f, _force = 10f;
    [SerializeField]
    private float _destroyPosZ = -20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BulletMovement();
    }
    void BulletMovement()
    {
        transform.Translate(Vector3.back * _speed * Time.deltaTime);
        if (transform.position.z < _destroyPosZ)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.Damage();
            Destroy(this.gameObject);
        }
    }
}
