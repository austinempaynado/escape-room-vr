using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenForTorch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Torch")
        {
            RoomOneEvents.current.LightTorch();
        }
    }

}
