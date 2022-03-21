using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePressurePlateDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RoomOneEvents.current.onPressurePlateStep += AnimateUpwards;
        RoomOneEvents.current.onPressurePlateStepOff += AnimateDownwards;
    }


    private void AnimateUpwards()
    {
        LeanTween.moveY(gameObject, 2.9f, 0.6f);
    }

    private void AnimateDownwards()
    {
        LeanTween.moveY(gameObject, 1.0f, 0.6f);
    }
}
