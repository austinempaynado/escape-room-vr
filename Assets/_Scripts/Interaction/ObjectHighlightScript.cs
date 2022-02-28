using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectHighlightScript : MonoBehaviour
{
    public Shader defaultShader;
    public Shader highlightedShader;

    public void OnFirstHoverEntered(HoverEnterEventArgs args)
    {
        //get the renderer component of the object we're hovering over
        var renderer = args.interactableObject.transform.GetComponent<Renderer>();

        //assign shader to the material of the object that we specify
        renderer.material.shader = highlightedShader;
    }

    public void OnLastHoverExited(HoverExitEventArgs args)
    {
        if (!args.interactableObject.isHovered)
        {
            var renderer = args.interactableObject.transform.GetComponent<Renderer>();
            renderer.material.shader = defaultShader;
        }
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        var renderer = args.interactableObject.transform.GetComponent<Renderer>();
        renderer.material.shader = highlightedShader;
    }

    public void OnSelectExited(SelectExitEventArgs args)
    {
        if (!args.interactableObject.isSelected)
        {
            var renderer = args.interactableObject.transform.GetComponent<Renderer>();
            renderer.material.shader = defaultShader;
        }
    }
}
