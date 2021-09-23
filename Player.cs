using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 10.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _doubleJump;
    private int _coins;
    private UIManager _uIManager;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private Transform _respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(_uIManager == null)
        {
            Debug.LogError("UI Manager on canvas is empty");
        }

        _uIManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;
        if(_controller.isGrounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _doubleJump = true;
            }
        }
        else
        {
            _yVelocity -= _gravity;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(_doubleJump == true)
                {
                    _yVelocity = _jumpHeight;
                    _doubleJump = false;
                }
            }
        }
        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoins()
    {
        _coins++;
        _uIManager.UpdateCoinDisplay(_coins);
    }

    public void Damage()
    {
        _lives--;
        _uIManager.UpdateLivesDisplay(_lives);

        if(_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
