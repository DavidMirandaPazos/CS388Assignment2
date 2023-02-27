using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : ActionTrigger
{
    public Door doorReference;

    public override void Trigger()
    {
        doorReference.Unlock();
    }

    public override void Reset()
    {
    }
}
