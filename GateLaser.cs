using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLaser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.Damage();
        }
    }
}
