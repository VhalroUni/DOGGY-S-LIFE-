using Steerings;
using TMPro;
using UnityEngine;

public class DOGGY_Blackboard : DynamicBlackboard
{

    public float timeOutTime = 10;
    public float elapsedTime;
    
    public GameObject currentPointOfInterest;

    public GameObject foodLocationOne; // where steaks are
    public GameObject foodLocationTwo; // where kibble is
    public GameObject stickAbandonArea; // where sticks are left
    public GameObject centreOfScene; // where doggy barks
    public GameObject housePrevious; // used by Hide
    public GameObject houseEntrance; // used by Hide
    public GameObject houseEnd; // used by Hide

    public float hunger = 0;
    public float hungerIncrement = 0.5f;
    public float hungryThreshold = 100;
    public float eatingTime = 3f;
    public float speedIncrementFactor = 3.5f;
    
    public TextMeshProUGUI label;

    private GameObject[] points;
    private bool increasedSpeed = false;
    private SteeringContext sContext;
    private GameObject kibble;
    private GameObject steaks;
    
    void Start()
    {
        sContext = GetComponent<SteeringContext>();
        
        centreOfScene = GameObject.Find("CentreOfScene");   
        
        foodLocationOne = GameObject.Find("FlagSteak");
        foodLocationTwo = GameObject.Find("FlagKibble");
        
        stickAbandonArea = GameObject.Find("StickAbandonArea");
        
        housePrevious = GameObject.Find("housePrevious");
        houseEntrance = GameObject.Find("houseEntrance");
        houseEnd = GameObject.Find("houseEnd");
        
        var xyz = GameObject.Find("HungerLabel");
        label = xyz.GetComponent<TextMeshProUGUI>();
        
        points = GameObject.FindGameObjectsWithTag("POINT");
        foreach (GameObject point in points) point.SetActive(false);
        currentPointOfInterest = GetRandomPoint();
        ChangePointOfInterest();
    }
    
    void Update()
    {
        elapsedTime += Time.deltaTime;
        hunger += hungerIncrement * Time.deltaTime;
        label.text = "Hunger: " + hunger.ToString("0.00");
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            makeHungry();
        }
    }

    public void ChangePointOfInterest()
    {
        //currentPointOfInterest.SetActive(false);
        currentPointOfInterest = GetRandomPoint();
        // currentPointOfInterest.SetActive(true);
    }
    
    public GameObject GetRandomPoint() {
        return points[Random.Range(0, points.Length)];  
    }
    
    public bool isTimeOut()
    {
        return elapsedTime >= timeOutTime;
    }   
    
    public void resetTimeOut() {
        elapsedTime = 0;
    }
    
    public bool isHungry()
    {
        return hunger >= hungryThreshold;
    }

    public void makeHungry()
    {
        hunger = 100;
    }
    
    public void resetHunger() {
        hunger = 0;
        foreach (GameObject food in GameObject.FindGameObjectsWithTag("FOOD")) {
            Destroy(food);
        }
    }
    
    public void increaseSpeed() {
        if (increasedSpeed) return;
        increasedSpeed = true;
        sContext.maxSpeed *= speedIncrementFactor;
        sContext.maxAcceleration *= speedIncrementFactor * 2;
    }
    
    public void decreaseSpeed() {
        if (!increasedSpeed) return;
        increasedSpeed = false;
        sContext.maxSpeed /= speedIncrementFactor;
        sContext.maxAcceleration /= speedIncrementFactor * 2;
    }
}
