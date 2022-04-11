using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinRoomPressurePlate : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ramp Weight" || other.tag == "Player")
        {
            RoomOneEvents.current.OnCoffinPlate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ramp Weight" || other.tag == "Player")
        {
            RoomOneEvents.current.OffCoffinPlate();
        }
    }
}
