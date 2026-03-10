using Steerings;
using UnityEngine;

public class BeThrown : MonoBehaviour
{
    public GameObject destination;
    public GameObject departureArea;
    public GameObject landingArea;
    public GameObject dog;
    public SpriteRenderer spriteRenderer;
    private Arrive arrive;
    private StickRotation rotation;
    private bool doNothing = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        departureArea = GameObject.Find("StickDepartureArea");
        landingArea = GameObject.Find("StickLandingArea");
        dog = GameObject.Find("DOGGY");
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        Bounds bounds = landingArea.GetComponent<SpriteRenderer>().bounds;
        Vector2 landingPosition = new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
        
        destination = new GameObject();
        destination.transform.position = landingPosition;
        
        bounds = departureArea.GetComponent<SpriteRenderer>().bounds;
        Vector2 startingPosition = new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
            );

        float minDistance = Mathf.Max(
            spriteRenderer.bounds.size.x, 
            spriteRenderer.bounds.size.y
        );
        Vector2 directionAB = landingPosition - startingPosition;
        Vector2 directionADog = (Vector2)dog.transform.position - startingPosition;
        float t = Vector2.Dot(directionADog, directionAB) / Vector2.Dot(directionAB, directionAB);
        t = Mathf.Clamp01(t);
        Vector2 closestPoint = startingPosition + directionAB * t;
        float distance = Vector2.Distance(closestPoint, dog.transform.position);
        if (distance <= 4*minDistance)
        {
            Debug.Log("Stick could hit doggy");
            doNothing = true;
        }
        else
        {
            gameObject.tag = "STICK";
            this.transform.position = startingPosition;
            arrive = GetComponent<Arrive>();
            rotation = GetComponent<StickRotation>();
            arrive.target = destination;
            arrive.enabled = true;
            rotation.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (doNothing) {Destroy(gameObject);
            Destroy(destination); return;}
        
        if (destination!=null && SensingUtils.DistanceToTarget(gameObject, destination) <= 1)
        {
            arrive.enabled = false;
            rotation.enabled = false;
            Destroy(destination);
        }
    }
}
