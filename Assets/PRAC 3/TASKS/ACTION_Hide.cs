using UnityEngine;
using BTs;

public class ACTION_Hide : Action
{
    /* Declare action parameters here. 
       All public parameters must be of type string. All public parameters must be
       regarded as keys in/for the blackboard context.
       Use prefix "key" for input parameters (information stored in the blackboard that must be retrieved)
       use prefix "keyout" for output parameters (information that must be stored in the blackboard)

       e.g.
       public string keyDistance;
       public string keyoutObject 
     */
    
    // construtor
    public ACTION_Hide()  { 
        /* Receive action parameters and set them */
    }
    
    /* Declare private attributes here */
    private InnerBt innerBt;
    private Status lastStatus = Status.LIMBO;

    public override void OnInitialize()
    {
        lastStatus = Status.LIMBO;
        innerBt = ScriptableObject.CreateInstance<InnerBt>();
        innerBt.Contextualize(gameObject);
    }

    public override Status OnTick ()
    {
        if (lastStatus != Status.FAILED && lastStatus != Status.SUCCEEDED)
        {
            lastStatus = innerBt.Tick();
        }
        return Status.RUNNING;
    }

    public override void OnAbort()
    {
        innerBt.Abort();
    }

    class InnerBt : BehaviourTree
    {
        public override void OnConstruction()
        {
            root = new Sequence(
                new ACTION_Arrive("housePrevious"),
                new ACTION_Arrive("houseEntrance", "2f"),
                new ACTION_Arrive("houseEnd")
            );
        }
    }

}
