using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public GameObject pivot;
    // Start is called before the first frame update
    void Start()
    {
        RoomOneEvents.current.onUnlockPurple += OpenChest;
    }

    private void OpenChest()
    {
        LeanTween.rotateX(pivot, 0, 1.5f);
    }
}
