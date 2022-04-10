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
    GameObject[] floors;

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

        floors = GameObject.FindGameObjectsWithTag("Floor");
    }

    public event Action enableColorblindMode;
    public event Action disablerColorblindMode;

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

    public void toggleRotation_OnValueChanged(bool isOn)
    {
        if (isOn)
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedSnapTurnProvider>().enabled = !GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedSnapTurnProvider>().enabled;
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedContinuousTurnProvider>().enabled = !GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedContinuousTurnProvider>().enabled;
        }
        else
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedSnapTurnProvider>().enabled = !GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedSnapTurnProvider>().enabled;
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedContinuousTurnProvider>().enabled = !GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedContinuousTurnProvider>().enabled;
        }
    }

    public void toggleMovement(bool isOn)
    {
        if (isOn)
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedContinuousMoveProvider>().enabled = !GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedContinuousMoveProvider>().enabled;
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<TeleportationProvider>().enabled = !GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<TeleportationProvider>().enabled;
            foreach(GameObject floor in floors)
            {
                floor.GetComponent<TeleportationArea>().enabled = !floor.GetComponent<TeleportationArea>().enabled;
            }
        }
        else
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedContinuousMoveProvider>().enabled = !GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedContinuousMoveProvider>().enabled;
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<TeleportationProvider>().enabled = !GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<TeleportationProvider>().enabled;
            foreach (GameObject floor in floors)
            {
                floor.GetComponent<TeleportationArea>().enabled = !floor.GetComponent<TeleportationArea>().enabled;
            }
        }
    }

    public void toggleColorblindMode()
    {

    }
}
