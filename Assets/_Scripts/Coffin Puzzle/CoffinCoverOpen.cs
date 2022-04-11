using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinCoverOpen : MonoBehaviour
{
    public AudioClip openingCasket;

    // Start is called before the first frame update
    void Start()
    {
        RoomOneEvents.current.onOpenCoffin += OpenCoffin;
    }

    private void OpenCoffin()
    {
        LeanTween.moveLocalX(gameObject, -0.4f, 1);
        GetComponent<AudioSource>().PlayOneShot(openingCasket);
    }
}
