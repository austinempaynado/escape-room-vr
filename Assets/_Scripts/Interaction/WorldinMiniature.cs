using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WorldinMiniature : MonoBehaviour
{
    public GameObject envObj;
    public Transform miniGenPoint;
    public float scaleVal; //scale value when scaling the interactables on the minigenpoint

    private Transform[] miniObjs;
    private GameObject miniEnvObj;
    private bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartRoutine");
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            for(int i = 0; i < envObj.transform.childCount; i++)
            {
                var obj = envObj.transform.GetChild(i);
                var miniObj = miniObjs[i];

                if (miniObj.parent != miniEnvObj.transform) miniObj.parent = miniEnvObj.transform;

                obj.localPosition = miniObj.localPosition;
                obj.localRotation = miniObj.localRotation;
            }
        }
    }

    //Coroutine
    IEnumerator StartRoutine()
    {
        yield return new WaitForSeconds(1f);
        miniEnvObj = Instantiate(envObj, miniGenPoint.position, miniGenPoint.rotation); //interactables container
        miniEnvObj.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);

        miniObjs = new Transform[envObj.transform.childCount];

        for(int i = 0; i < envObj.transform.childCount; i++)
        {
            var obj = envObj.transform.GetChild(i);
            obj.GetComponent<XRGrabInteractable>().enabled = false;

            miniObjs[i] = miniEnvObj.transform.GetChild(i);
        }

        isStarted = true;
    }
}
