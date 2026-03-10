using System.ComponentModel.Design.Serialization;
using UnityEngine;
using BTs;
using UnityEditor.Profiling.Memory.Experimental;

[CreateAssetMenu(fileName = "BT_Bully", menuName = "Behaviour Trees/BT_Bully", order = 1)]
public class BT_Bully : BehaviourTree
{
    /* If necessary declare BT parameters here. 
       All public parameters must be of type string. All public parameters must be
       regarded as keys in/for the blackboard context.
       Use prefix "key" for input parameters (information stored in the blackboard that must be retrieved)
       use prefix "keyout" for output parameters (information that must be stored in the blackboard)

       e.g.
       public string keyDistance;
       public string keyoutObject 

       NOTICE: BT's with parameters cannot be constructed using ScriptableObject.CreateInstance<>
       An explicit constructor with new must be used. Unity will complain...
       Whenever possible, use parameter-less BT's. Use blackboard to pass information.
       TOP-level BTs (those attached to the executor) cannot have parameters
       
       In future versions, BT parameters may cease to exit

     */

     // construtor
    public BT_Bully()  { 
        /* Receive BT parameters and set them. Remember all are of type string */
    }
    
    public override void OnConstruction()
    {
        root = new Sequence();
        root.AddChild(new LambdaAction(() =>
        {   gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GameObject [] starts = GameObject.FindGameObjectsWithTag("BULLYSTART");
            gameObject.transform.position = starts[Random.Range(0,starts.Length)].transform.position;
            return Status.SUCCEEDED;
        }));
        root.AddChild(new LambdaAction(() =>
        {   GameObject [] dests = GameObject.FindGameObjectsWithTag("BULLYDEST");
            blackboard.Put("$dest$", dests[Random.Range(0,dests.Length)]);
            return Status.SUCCEEDED;
        }));
        root.AddChild(new ACTION_Arrive("$dest$", "1"));
        root.AddChild(new LambdaAction(() => { Destroy(gameObject,0.25f); return Status.SUCCEEDED; 
        }));
    }
}
