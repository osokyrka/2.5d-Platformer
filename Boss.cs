using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private int _health = 4;
    [SerializeField]
    private GameObject _explosionPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }
    
    private void Death()
    {
        if (_health <= 0)
        {
            GameObject explosionPrefab = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosionPrefab, 1f);
        }
    }

    public void Damage()
    {
        _health-=1;
    }
}
