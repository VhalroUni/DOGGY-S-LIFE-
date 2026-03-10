using UnityEngine;
using BTs;

public class CONDITION_IsHungry : Condition
{
    public override bool Check ()
    {
        DOGGY_Blackboard bl = (DOGGY_Blackboard)blackboard;
        return bl.isHungry();
    }

}
