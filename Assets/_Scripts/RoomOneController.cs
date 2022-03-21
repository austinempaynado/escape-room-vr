using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOneController : MonoBehaviour
{

    private int locksOpened = 0;
    // Start is called before the first frame update
    void Start()
    {
        RoomOneEvents.current.onLockCount += increaseUnlockCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(locksOpened == 2)
        {
            RoomOneEvents.current.OpenCoffin();
        }
    }

    private void increaseUnlockCount()
    {
        locksOpened += 1;
    }
}
