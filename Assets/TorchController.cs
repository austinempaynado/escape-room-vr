using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    public GameObject flame;
    // Start is called before the first frame update
    void Start()
    {
        RoomOneEvents.current.onLightTorch += lightTorch;
    }

    private void lightTorch()
    {
        flame.SetActive(true);
    }
}
