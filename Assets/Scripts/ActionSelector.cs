using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelector : MonoBehaviour
{
    GameObject hitObject;

    float hitTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(new Ray(transform.position, transform.forward), out hit, 200);

        if (hit.collider != null && hit.collider.gameObject == hitObject)
        {
            if (hitObject.GetComponent<ActionTrigger>() != null)
            {
                if (hitTime >= 3.0f)
                {
                    hitObject.GetComponent<ActionTrigger>().Trigger();
                    hitTime = 0.0f;
                }

                hitTime += Time.deltaTime;
                Debug.Log("Updating Time");
            }
        }
        else if (hit.collider != null && hit.collider.gameObject != hitObject)
        {
            hitObject = hit.collider.gameObject;
            hitTime = 0.0f;
            Debug.Log("Updated HIT object.");
        }
    }
}
