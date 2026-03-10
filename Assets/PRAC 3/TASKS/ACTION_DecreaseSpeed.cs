using UnityEngine;
using BTs;

public class ACTION_DecreaseSpeed : Action
{
    public override Status OnTick()
    {
        ((DOGGY_Blackboard)blackboard).decreaseSpeed();
        return Status.SUCCEEDED;
    }
}
