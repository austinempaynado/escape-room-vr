using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    public static TorchController current;
    private void Awake()
    {
        current = this;
    }

    [HideInInspector] public bool isLit =false;
    public GameObject flame;
    // Start is called before the first frame update
    void Start()
    {
        RoomOneEvents.current.onLightTorch += lightTorch;
    }

    private void lightTorch()
    {
        flame.SetActive(true);
        isLit = true;
    }
}
