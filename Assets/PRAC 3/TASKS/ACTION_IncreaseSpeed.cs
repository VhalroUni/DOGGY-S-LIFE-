using UnityEngine;
using BTs;

public class ACTION_IncreaseSpeed : Action
{
    public override Status OnTick ()
    {
        ((DOGGY_Blackboard)blackboard).increaseSpeed();
        return Status.SUCCEEDED;
    }
}
