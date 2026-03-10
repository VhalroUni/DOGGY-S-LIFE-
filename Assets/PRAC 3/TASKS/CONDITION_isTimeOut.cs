using UnityEngine;
using BTs;

public class CONDITION_isTimeOut : Condition
{
    
    // Constructor
    public CONDITION_isTimeOut()  {
        /* Receive function parameters and set them */
    }

    // optional
    public override void OnInitialize()
    {
        /* implement this method for conditions that have state and/or
        for conditions that may be called many times in the same ticking cycle
        (e.g. conditions in dynamic selectors). 
        If in doubt, do not implement it. Do all the work in Check */
    }

    public override bool Check ()
    {
        DOGGY_Blackboard bl = (DOGGY_Blackboard)blackboard;
        return bl.isTimeOut();
    }

}
