using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System;

public class Menu : MonoBehaviour
{

    public Canvas menuUI;
    private bool isMenuPressed = false;
    public static Menu current = null;

    // Start is called before the first frame update
    void Start()
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public event Action toggleColorblindMode;
    public event Action toggleContinuousMovement;
    public event Action toggleContinuousRotation;
    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), InputHelpers.Button.MenuButton, out bool isPressed);

        if (isPressed)
        {
            if (!isMenuPressed)
            {
                menuUI.enabled = !menuUI.enabled;
            }
            isMenuPressed = true;
        }
        else
        {
            isMenuPressed = false;
        }
    }

    public void toggleRotation(bool isOn)
    {

    }
}
