using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableItemInside : Destructable
{
    public GameObject containedObject;

    protected override void changeStateToDestroyed()
    {
        base.changeStateToDestroyed();
        Instantiate(containedObject, transform.position, transform.rotation);
    }
}
