using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHoldTransform : MonoBehaviour
{

    public GameObject hand;

    // Update is called once per frame
    void Update()
    {
        transform.position = hand.transform.forward * -1.1f;
    }
}
