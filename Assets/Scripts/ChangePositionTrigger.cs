using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionTrigger : ActionTrigger
{
    bool triggered = false;
    float interpolationTime;
    Vector3 originalPosition;

    public GameObject cameraObject;

    // Update is called once per frame
    void LateUpdate()
    {
        if (triggered)
        {
            cameraObject.transform.position = Vector3.Lerp(originalPosition, gameObject.transform.position, interpolationTime / 5.0f);

            interpolationTime += Time.deltaTime;
        }
    }
    public override void Trigger()
    {
        triggered = true;
        interpolationTime = 0.0f;
        originalPosition = cameraObject.transform.position;
    }
}
