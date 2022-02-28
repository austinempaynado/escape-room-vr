using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject destroyedVersion;
    public float breakSpeed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= breakSpeed)
        {
            changeStateToDestroyed();
        }
    }

    protected virtual void changeStateToDestroyed()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
