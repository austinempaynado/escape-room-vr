using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePressurePlateDoor : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    public AudioClip DoorOpen;
    public AudioClip DoorClose;
    void Start()
    {
        RoomOneEvents.current.onPressurePlateStep += AnimateUpwards;
        RoomOneEvents.current.onPressurePlateStepOff += AnimateDownwards;

        audioSource = GetComponent<AudioSource>();
    }


    private void AnimateUpwards()
    {
        LeanTween.moveY(gameObject, 2.9f, 0.6f);
        audioSource.PlayOneShot(DoorOpen);
    }

    private void AnimateDownwards()
    {
        LeanTween.moveY(gameObject, 1.0f, 0.6f);
        audioSource.PlayOneShot(DoorClose);
    }
}
