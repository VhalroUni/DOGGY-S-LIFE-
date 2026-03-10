using UnityEngine;
using TMPro;
using BTs;

public class ACTION_Bark : Action
{

    public string keyMessage;


    // construtor
    public ACTION_Bark(string keyMessage)  {
        this.keyMessage = keyMessage;
    }

    private string theMessage;
    private GameObject bubble;
    private TextMeshPro textLine;

    public override void OnInitialize()
    {
        theMessage = blackboard.Get<string>(keyMessage);
        bubble = FindChildWithTag(gameObject, "BUBBLE");
        if (bubble != null) textLine = bubble.transform.GetChild(0).GetComponent<TextMeshPro>();
    }

    public override Status OnTick ()
    {
        if (textLine != null)
        {
            bubble.SetActive(true);
            textLine.text = theMessage;
            return Status.SUCCEEDED;
        }
        else
            return Status.FAILED;
    }

    public override void OnAbort()
    {
        if (textLine != null)
            bubble.SetActive(false);
    }
   
    // -----------------

    private GameObject FindChildWithTag(GameObject go, string tag)
    {
        for (int i = 0; i < go.transform.childCount; i++)
        {
            if (go.transform.GetChild(i).tag == tag)
                return go.transform.GetChild(i).gameObject;
            for (int j=0; j<go.transform.GetChild(i).childCount; j++) 
                if (go.transform.GetChild(i).transform.GetChild(j).tag == tag)
                    return go.transform.GetChild(i).GetChild(j).gameObject;
        }
        return null;
    }

}
