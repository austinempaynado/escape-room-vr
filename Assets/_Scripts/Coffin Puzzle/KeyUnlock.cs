using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUnlock : MonoBehaviour
{
    public AudioClip unlock;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Room One Key")
        {
            RoomOneEvents.current.LockCount();
            Destroy(other.gameObject);
            GetComponent<AudioSource>().PlayOneShot(unlock);
            StartCoroutine("Destroy");
        }
    }


    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);

    }
}