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
    public event Action onLockCount;
    public event Action onOpenCoffin;
    public event Action onUnlockPurple;
    public event Action onPressurePlateStep;
    public event Action onPressurePlateStepOff;
    public event Action onCoffinPressurePlateStep;
    public event Action offCoffinPressurePlateStep;

    public void LightTorch()
    {
        onLightTorch?.Invoke();
    }

    public void LockCount()
    {
        onLockCount?.Invoke();
    }

    public void OpenCoffin()
    {
        onOpenCoffin?.Invoke();
    }

    public void OpenPurpleLock()
    {
        onUnlockPurple?.Invoke();
    }

    public void OpenPressurePlateDoor()
    {
        onPressurePlateStep?.Invoke();
    }

    public void ClosePressurePlateDoor()
    {
        onPressurePlateStepOff?.Invoke();
    }

    public void OnCoffinPlate()
    {
        onCoffinPressurePlateStep?.Invoke();
    }

    public void OffCoffinPlate()
    {
        offCoffinPressurePlateStep?.Invoke();
    }
}
