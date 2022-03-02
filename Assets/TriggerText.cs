using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    public GameObject text;
    public GameObject mainCamera;
    public bool DestroyAfterExit = false;

    private void Update()
    {
        text.transform.rotation = mainCamera.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            text.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
            text.SetActive(false);

        if (other.gameObject.tag == "Player" && DestroyAfterExit)
            text.SetActive(false);
            Destroy(text);
            Destroy(gameObject);

    }
}
