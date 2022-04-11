using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTwoDoorTrigger : MonoBehaviour
{
    public GameObject pivot;
    public AudioClip doorOpen;
    public AudioClip unlock;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "KeyToRoomTwo")
        {
            LeanTween.moveY(pivot, 3, 2f);
            GetComponent<AudioSource>().PlayOneShot(doorOpen);
            GetComponent<AudioSource>().PlayOneShot(unlock);
            StartCoroutine("Destroy");
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
