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

    public GameObject Page1;
    public GameObject Page2;

    // Start is called before the first frame update
    void Awake()
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

    public event Action EnableColorblindMode;
    public event Action DisablerColorblindMode;

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

    public void toggleColorblindMode(bool isOn)
    {
        if (isOn)
        {
            EnableColorblindMode?.Invoke();
        }
        else
        {
            DisablerColorblindMode?.Invoke();
        }
    }

    public void ChangeToPage1()
    {
        Page1.SetActive(true);
        Page2.SetActive(false);
    }

    public void ChangeToPage2()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
    }

    public void CloseUI()
    {
        menuUI.enabled = !menuUI.enabled;
    }
}
