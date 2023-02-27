using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTrigger : MonoBehaviour
{
    public bool finished = false;
    public bool triggered = false;
    public Material defaultMaterial;
     
    public virtual void Trigger()
    {

    }

    public virtual void Reset()
    {
        gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
        finished = false;
    }
}
