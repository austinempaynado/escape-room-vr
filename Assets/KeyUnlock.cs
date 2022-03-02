using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUnlock : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Room One Key")
        {
            RoomOneEvents.current.LockCount();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }


}
