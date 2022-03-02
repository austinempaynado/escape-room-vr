using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOneEvents : MonoBehaviour
{
    public static RoomOneEvents current = null;
    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
    }

    public event Action onLightTorch;

    public void LightTorch()
    {
        onLightTorch?.Invoke();
    }
}
