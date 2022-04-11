using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLock : MonoBehaviour
{
    public AudioClip unlockSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Chest Key")
        {
            //activate event

            RoomOneEvents.current.OpenPurpleLock();
            Destroy(other.gameObject);
            GetComponent<AudioSource>().PlayOneShot(unlockSound);
            StartCoroutine("DestroyLock");

        }
    }


    IEnumerator DestroyLock()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
