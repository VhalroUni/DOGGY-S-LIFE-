using UnityEngine;

public class ControlManager : MonoBehaviour
{
    private GameObject kibble;
    private GameObject steak;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        kibble = GameObject.Find("FlagKibble");
        steak = GameObject.Find("FlagSteak");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            spawnStick();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            ProduceKibble();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ProduceSteak();
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBully();
        }
    }
    
    public void spawnStick()
    {
        // should not work if another stick is still active
        if (GameObject.FindGameObjectWithTag("STICK") != null)
        {
            Debug.Log("Stick already active");
            return;
        }
        Instantiate(Resources.Load("Stick"));
    }

    public void SpawnBully()
    {
        // should not work if another "bully" is still active"
        if (GameObject.FindGameObjectWithTag("BULLY") != null)
        {
            Debug.Log("Bully already active");
            return;
        }
        Instantiate(Resources.Load("BULLY"));
    }
    
    public void ProduceKibble()
    {
        if (GameObject.FindGameObjectWithTag("FOOD") != null)
        {
            Debug.Log("Food already active");
            return;
        }
        GameObject kibbleInstance = (GameObject)Instantiate(Resources.Load("Kibble"));
        kibbleInstance.transform.position = kibble.transform.position;
    }

    public void ProduceSteak()
    {
        if (GameObject.FindGameObjectWithTag("FOOD") != null)
        {
            Debug.Log("Food already active");
            return;
        }
        GameObject steakInstance = (GameObject)Instantiate(Resources.Load("Steaks"));
        steakInstance.transform.position = steak.transform.position;
    }
}
