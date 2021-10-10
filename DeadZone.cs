using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawnPoint;
    [SerializeField]
    private GameObject _respawnPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;
            }
            other.transform.position = _respawnPoint.transform.position;
            StartCoroutine(CCEnableRoutine(cc));
            GameObject respawnPrefab = Instantiate(_respawnPrefab, other.transform.position, Quaternion.identity);
            Destroy(respawnPrefab, 1f);
        }
    }

    IEnumerator CCEnableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.2f);
        controller.enabled = true;
    }
}
