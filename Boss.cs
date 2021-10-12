using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private int _health = 4;
    [SerializeField]
    private GameObject _explosionPrefab = null;
    private UIManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
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
            _uiManager.UpdateLevel();
            CharacterController player = GameObject.Find("Player").GetComponent<CharacterController>();
            player.enabled = false;
        }
    }

    public void Damage()
    {
        _health-=1;
    }
}
