using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenForTorch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Torch")
        {
            RoomOneEvents.current.LightTorch();
        }
    }

}
