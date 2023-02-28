using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : ActionTrigger
{
    public Door doorReference;

    public override void Trigger()
    {
        defaultMaterial = gameObject.GetComponent<MeshRenderer>().material;
        doorReference.Unlock();
        finished = true;
    }

    public override void Reset()
    {
    }
}
