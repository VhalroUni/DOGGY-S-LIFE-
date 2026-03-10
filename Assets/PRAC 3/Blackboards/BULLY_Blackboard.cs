using UnityEngine;

public class BULLY_Blackboard : DynamicBlackboard
{
    private GameObject[] destinations;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destinations = GameObject.FindGameObjectsWithTag("BULLYDEST");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public GameObject GetRandomDestination()
    {
        return destinations[Random.Range(0, destinations.Length)];
    }
}
