using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePuzzleTile : MonoBehaviour
{
    public Color[] colorList;

    Color correctColor;
    int colorIndex = 0;
    public Renderer renderObject;
    public int correctColorIndex;
    public bool isLeft;
    public bool isRight;
    public bool isMiddle;

    // Start is called before the first frame update
    void Start()
    {
        renderObject.material.color = colorList[colorIndex];
        correctColor = colorList[correctColorIndex];
    }

    public void ChangeColor()
    {
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
}
