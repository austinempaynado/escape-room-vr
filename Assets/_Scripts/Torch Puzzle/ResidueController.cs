using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidueController : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Torch" && TorchController.current.isLit)
        {
            door.SetActive(false);
        }
    }
}
