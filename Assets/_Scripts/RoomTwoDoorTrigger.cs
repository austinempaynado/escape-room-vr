using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTwoDoorTrigger : MonoBehaviour
{
    public GameObject pivot;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "KeyToRoomTwo")
        {
            LeanTween.moveY(pivot, 3, 1f);
            Destroy(gameObject);
        }
    }
}
