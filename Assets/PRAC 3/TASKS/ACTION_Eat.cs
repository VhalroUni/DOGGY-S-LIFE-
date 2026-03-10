using UnityEngine;
using BTs;

public class ACTION_Eat : Action
{

    private float elaspsedTime = 0f;
    private DOGGY_Blackboard bl;
    
    // construtor
    public ACTION_Eat()  { 
        /* Receive action parameters and set them */
    }
    
    /* Declare private attributes here */

    public override void OnInitialize()
    {
        elaspsedTime = 0f;
        bl = (DOGGY_Blackboard)blackboard;
           
    }

    public override Status OnTick ()
    {
        elaspsedTime += Time.deltaTime;
        if (elaspsedTime >= bl.eatingTime)
        {
            bl.resetHunger();
            return Status.SUCCEEDED;
        }
        return Status.RUNNING;
    }

    public override void OnAbort()
    {
        // write here the code to be executed if the action is aborted while running
    }

}
