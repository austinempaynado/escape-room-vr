using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateRamp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RoomOneEvents.current.onCoffinPressurePlateStep += AnimateDownwards;
        RoomOneEvents.current.offCoffinPressurePlateStep += AnimateUpwards;
    }

    private void AnimateUpwards()
    {
        LeanTween.moveLocalX(gameObject, 4.44f, 1.0f);
        LeanTween.moveLocalY(gameObject, 3.36f, 1.0f);
    }

    private void AnimateDownwards()
    {
        LeanTween.moveLocalX(gameObject, 7.285f, 1.0f);
        LeanTween.moveLocalY(gameObject, 1.045f, 1.0f);
    }
}
