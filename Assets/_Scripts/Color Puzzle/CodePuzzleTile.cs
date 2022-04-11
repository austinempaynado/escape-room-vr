using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePuzzleTile : MonoBehaviour
{
    public AudioClip UISound;
    private AudioSource audioSource;

    public Color[] colorList;
    public Sprite[] imageList;

    Color correctColor;
    int colorIndex = 0;
    public Renderer renderObject;
    public int correctColorIndex;

    public Image imageObject;
    Sprite correctImage;
    int imageIndex;
    public int correctImageIndex;

    private bool colorBlindMode = false;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        colorIndex = 0;
        imageIndex = 0;

        renderObject.material.color = colorList[colorIndex];
        correctColor = colorList[correctColorIndex];


        correctImage = imageList[correctImageIndex];


        if(Menu.current!=null)
            Menu.current.EnableColorblindMode += EnableColorblindMode;
            Menu.current.DisablerColorblindMode += DisableColorblindMode;
    }

    public void ChangeColor()
    {
        audioSource.PlayOneShot(UISound);

        if (!colorBlindMode)
        {
            ChangeDisplayColor();
        }
        else
        {
            ChangeImage();
        }
    }

    public void ChangeDisplayColor(){
        colorIndex++;

        if (colorIndex < colorList.Length)
        {
            renderObject.material.color = colorList[colorIndex];
        }

        if (colorIndex >= colorList.Length)
        {
            colorIndex = 0;
            renderObject.material.color = colorList[colorIndex];
        }

        if ((int)(renderObject.material.color.r * 1000) == (int)(correctColor.r * 1000) &&
            (int)(renderObject.material.color.g * 1000) == (int)(correctColor.g * 1000) &&
            (int)(renderObject.material.color.b * 1000) == (int)(correctColor.b * 1000))
        {
            CodePuzzle.current.count += 1;
        }

        if ((correctColorIndex + 1) < colorList.Length)
        {
            if ((int)(renderObject.material.color.r * 1000) == (int)(colorList[correctColorIndex + 1].r * 1000) &&
                (int)(renderObject.material.color.g * 1000) == (int)(colorList[correctColorIndex + 1].g * 1000) &&
                (int)(renderObject.material.color.b * 1000) == (int)(colorList[correctColorIndex + 1].b * 1000))
            {
                CodePuzzle.current.count -= 1;
            }
        }
        else if ((correctColorIndex + 1) == colorList.Length)
        {
            if ((int)(renderObject.material.color.r * 1000) == (int)(colorList[0].r * 1000) &&
                (int)(renderObject.material.color.g * 1000) == (int)(colorList[0].g * 1000) &&
                (int)(renderObject.material.color.b * 1000) == (int)(colorList[0].b * 1000))
            {
                CodePuzzle.current.count -= 1;
            }
        }

        Debug.Log(CodePuzzle.current.count);
    }

    public void ChangeImage()
    {
        imageIndex++;
        if (imageIndex < imageList.Length)
        {
            imageObject.sprite = imageList[imageIndex];
        }

        if (imageIndex >= imageList.Length)
        {
            imageIndex = 0;
            imageObject.sprite = imageList[imageIndex];
        }

        if(imageIndex == correctImageIndex)
        {
            CodePuzzle.current.count += 1;
        }

        if(imageIndex == (correctImageIndex + 1)){
            CodePuzzle.current.count -= 1;
        }
    }

    public void DisableColorblindMode()
    {
        imageIndex = 0;
        imageObject.enabled = !imageObject.enabled;

        colorIndex = 0;
        renderObject.material.color = colorList[colorIndex];

        CodePuzzle.current.count = 0;
        colorBlindMode = false;

    }

    private void EnableColorblindMode() {
        imageIndex = 0;
        imageObject.enabled = !imageObject.enabled;

        colorIndex = 0;
        renderObject.material.color = Color.white;

        CodePuzzle.current.count = 0;
        colorBlindMode = true;
    }



}
