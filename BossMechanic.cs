using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechanic : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;
    private bool _buttonActive = false;
    [SerializeField]
    private Boss _boss;
    [SerializeField]
    private Collider _collider;
    // Start is called before the first frame update
    private void Start()
    {
        _boss = GameObject.Find("Boss").GetComponent<Boss>();
        //_collider = GetComponent<Collider>();
    }
    private void Update()
    {
        if (_buttonActive == true)
        {
            _boss.Damage();
            _buttonActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _anim.SetTrigger("ButtonPress");
            _buttonActive = true;
            _collider.enabled = false;
        }
    }
}
