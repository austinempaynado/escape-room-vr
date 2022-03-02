using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinCoverOpen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RoomOneEvents.current.onOpenCoffin += OpenCoffin;
    }

    private void OpenCoffin()
    {
        LeanTween.moveLocalX(gameObject, 2, 1);
    }
}