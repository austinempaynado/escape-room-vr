using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float animationTime = 1f;
    public float animateToY = 2f;

    // Update is called once per frame
    void Start()
    {
        animateHover();
    }

    private void animateHover()
    {
        LeanTween.moveLocalY(gameObject, gameObject.transform.position.y + animateToY, animationTime).setEase(LeanTweenType.easeInOutQuad).setLoopPingPong();
    }
}
