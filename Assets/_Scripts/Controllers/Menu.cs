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
    private AudioSource audioSource;
    public AudioClip Back;
    public AudioClip Forward;
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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

            audioSource.PlayOneShot(Forward);
        }
        else
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedSnapTurnProvider>().enabled = !GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedSnapTurnProvider>().enabled;
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedContinuousTurnProvider>().enabled = !GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedContinuousTurnProvider>().enabled;
            audioSource.PlayOneShot(Back);
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
            audioSource.PlayOneShot(Forward);
        }
        else
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedContinuousMoveProvider>().enabled = !GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ActionBasedContinuousMoveProvider>().enabled;
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<TeleportationProvider>().enabled = !GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<TeleportationProvider>().enabled;
            foreach (GameObject floor in floors)
            {
                floor.GetComponent<TeleportationArea>().enabled = !floor.GetComponent<TeleportationArea>().enabled;
            }
            audioSource.PlayOneShot(Back);
        }
    }

    public void toggleColorblindMode(bool isOn)
    {
        if (isOn)
        {
            EnableColorblindMode?.Invoke();
            audioSource.PlayOneShot(Forward);
        }
        else
        {
            DisablerColorblindMode?.Invoke();
            audioSource.PlayOneShot(Back);
        }
    }

    public void ChangeToPage1()
    {
        Page1.SetActive(true);
        Page2.SetActive(false);
        audioSource.PlayOneShot(Forward);
    }

    public void ChangeToPage2()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
        audioSource.PlayOneShot(Forward);
    }

    public void CloseUI()
    {
        menuUI.enabled = !menuUI.enabled;
        audioSource.PlayOneShot(Forward);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
