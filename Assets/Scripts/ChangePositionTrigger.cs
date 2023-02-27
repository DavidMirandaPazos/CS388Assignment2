using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionTrigger : ActionTrigger
{

    public float maxTime = 5.0f;
    float interpolationTime;

    Vector3 originalPosition;

    public GameObject cameraObject;

    LayerMask defaultLayerMask;
    LayerMask ignoreLayerMask;

    void Start()
    {
        defaultMaterial = gameObject.GetComponent<MeshRenderer>().material;
        defaultLayerMask = LayerMask.NameToLayer("Default");
        ignoreLayerMask = LayerMask.NameToLayer("Ignore Raycast");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (triggered)
        {
            if(interpolationTime > maxTime)
            {
                triggered = false;
                finished = true;
                return;
            }
            cameraObject.transform.position = Vector3.Lerp(originalPosition, gameObject.transform.position, interpolationTime / maxTime);
            interpolationTime += Time.deltaTime;
        }
    }
    public override void Trigger()
    {
        gameObject.layer = ignoreLayerMask;
        triggered = true;
        interpolationTime = 0.0f;
        originalPosition = cameraObject.transform.position;
    }

    public override void Reset()
    {
        base.Reset();
        gameObject.layer = defaultLayerMask;
        triggered = false;
    }
}
