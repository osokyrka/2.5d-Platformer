using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _coinExplosion = null;
    [SerializeField]
    private GameObject _particlePrefab;

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.AddCoins();
                _coinExplosion.Play();
                GameObject explosionPrefab = Instantiate(_particlePrefab, other.transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(explosionPrefab, 0.5f);
            }
        }
    }

    
}
