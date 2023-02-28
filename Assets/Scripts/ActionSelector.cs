using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelector : MonoBehaviour
{
    GameObject hitObject;

    ActionTrigger lastObjectTriggered;

    public Material selectedMaterial;
    public Material triggeredMaterial;

    float hitTime = 0.0f;

    const float maxDistance = 200.0f;
    LayerMask layerMask;

    void Start()
    {
        layerMask = LayerMask.GetMask("Default");
    }

    // Update is called once per frame
    void Update()
    {
        // Before doing anything else, check that we are not locked while something
        // is triggered
        if (lastObjectTriggered == null || lastObjectTriggered.finished)
        {
            // Take the default layer
            RaycastHit hit;
            Physics.Raycast(new Ray(transform.position, transform.forward), out hit, maxDistance, layerMask);

            // Check that the raycast did hit something and that it is the same
            // as the previous hit
            if (hit.collider != null && hit.collider.gameObject == hitObject)
            {
                ActionTrigger actionTrigger = hitObject.GetComponent<ActionTrigger>();
                // Check that the hit object has the ActionTrigger component
                if (actionTrigger != null)
                {
                    // If it has been hit for more than three seconds, trigger it
                    if (hitTime >= 3.0f)
                    {
                        actionTrigger.Trigger();

                        if (lastObjectTriggered != null)
                            lastObjectTriggered.Reset();

                        lastObjectTriggered = actionTrigger;
                        hitTime = 0.0f;
                        hitObject.GetComponent<MeshRenderer>().material = triggeredMaterial;
                    }
                    else
                        hitObject.GetComponent<MeshRenderer>().material = selectedMaterial;

                    hitTime += Time.deltaTime;
                    Debug.Log("Updating Time");
                }
            }
            // Check that the raycast did hit something and that it is different from
            // the previous object hit
            else if (hit.collider != null && hit.collider.gameObject != hitObject)
            {
                // Check that we already had hit something
                // If that is the case, reset its color
                if (hitObject != null && hitObject.GetComponent<ActionTrigger>() != null)
                    hitObject.GetComponent<MeshRenderer>().material = hitObject.GetComponent<ActionTrigger>().defaultMaterial;

                hitObject = hit.collider.gameObject;

                hitTime = 0.0f;
                Debug.Log("Updated HIT object.");
            }
            // We did not hit anything, but in the previous check we had hit something
            else if(hit.collider == null && hitObject != null)
            {
                Debug.Log("Nothing hit");
                // Check that we already had hit something
                // If that is the case, reset its color
                if (hitObject != null && hitObject.GetComponent<ActionTrigger>() != null)
                    hitObject.GetComponent<MeshRenderer>().material = hitObject.GetComponent<ActionTrigger>().defaultMaterial;
            }
        }
    }
}
