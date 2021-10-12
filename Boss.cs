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
    private bool _isDead = false;
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            _isDead = true;
            GameObject explosionPrefab = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosionPrefab, 1f);
            _uiManager.UpdateLevel();
            Time.timeScale = 0;
            CharacterController player = GameObject.Find("Player").GetComponent<CharacterController>();
            player.enabled = false;
        }
    }


    public void Damage()
    {
        _health-=1;
    }
}
