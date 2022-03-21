using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLock : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Chest Key")
        {
            //activate event
            RoomOneEvents.current.OpenPurpleLock();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
