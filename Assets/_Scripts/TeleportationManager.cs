using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{

    //code courtesy of Justin Barnett https://www.youtube.com/watch?v=cxRnK8aIUSI

    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider provider;
    private InputAction _thumbstick;
    private bool _isActive;

    void Start()
    {
        rayInteractor.enabled = false;

        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        var cancel = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.canceled += OnTeleportCancel;

        _thumbstick = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Move");
        _thumbstick.Enable();
    }

    private void Update()
    {
        //when not active, get the position of the ray

        if (!_isActive)
            return;

        if (_thumbstick.triggered)
            return;

        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            _isActive = false;
            return;
        }
        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point
        };
        provider.QueueTeleportRequest(request);
        rayInteractor.enabled = false;
        _isActive = false;

    }
    void OnTeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        _isActive = true;
    }

    void OnTeleportCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        _isActive = false;
    }
}
