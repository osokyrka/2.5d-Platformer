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
    private Vector3 _camPos;
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
        else if(_player.transform.position.x > 120 && _player.transform.position.x < 250)
        {
            Quaternion target = Quaternion.Euler(30, 20, 20);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
        }
        else if(_player.transform.position.x > 250 && transform.position.x < 290)
        {
            Quaternion target = Quaternion.Euler(30, 0, 20);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
        }
        else if (_player.transform.position.x > 290 && transform.position.x < 350)
        {
            Quaternion target = Quaternion.Euler(30, 0, 10);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
        }
        else if (_player.transform.position.x > 350)
        {
            
            Quaternion target = Quaternion.Euler(20, 0, 0);
            //transform.position = new Vector3(0, 30, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
        }
        
    }
}
