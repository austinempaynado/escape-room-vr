using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePuzzle : MonoBehaviour
{
    public static CodePuzzle current = null;
    public int count = 0;
    public GameObject tiles, leftPivot, rightPivot;
    private bool locked = true;
    public AudioClip creakingdoor;

    // Start is called before the first frame update
    void Start()
    {
        if(current == null)
        {
            current = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 3 && locked)
        {
            Debug.Log("open cabinet");
            Destroy(tiles);
            OpenCabinet();
            locked = false;
        }
    }

    private void OpenCabinet()
    {
        LeanTween.rotateY(leftPivot, 140.0f, 2.0f);
        GetComponent<AudioSource>().PlayOneShot(creakingdoor);
    }
}
