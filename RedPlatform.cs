using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject _platform;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(DestroyPlatform());
            _anim.SetTrigger("death");
        }
    }

    IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
