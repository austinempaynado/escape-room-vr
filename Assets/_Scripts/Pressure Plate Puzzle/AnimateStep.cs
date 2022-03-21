using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateStep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RoomOneEvents.current.onPressurePlateStep += AnimateDownwards;
        RoomOneEvents.current.onPressurePlateStepOff += AnimateUpwards;
    }

    private void AnimateDownwards()
    {
        LeanTween.moveY(gameObject, -0.03f, 0.5f);
    }

    private void AnimateUpwards()
    {
        LeanTween.moveY(gameObject, 0.04f, 0.5f);
    }
}
