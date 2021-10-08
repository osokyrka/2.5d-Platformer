using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform _firstSwitchLocation;
    private Player _player;
    [SerializeField]
    private float _smooth = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCameraRotation();
        
    }

    void ChangeCameraRotation()
    {
        if (_player.transform.position.x < 120)
        {
            Quaternion target = Quaternion.Euler(30, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
        }
        if(_player.transform.position.x > 120)
        {
            Quaternion target = Quaternion.Euler(30, 20, 20);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
        }
        if(_player.transform.position.x > 250)
        {
            Quaternion target = Quaternion.Euler(30, -50, 20);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
        }
    }
}
