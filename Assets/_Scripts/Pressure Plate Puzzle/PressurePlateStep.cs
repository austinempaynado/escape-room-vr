using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateStep : MonoBehaviour
{
    private int itemCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Sack Weight")
        {
            itemCount++;
            RoomOneEvents.current.OpenPressurePlateDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Sack Weight")
        {
            itemCount--;
            if(itemCount == 0)
                RoomOneEvents.current.ClosePressurePlateDoor();
        }
    }
}
