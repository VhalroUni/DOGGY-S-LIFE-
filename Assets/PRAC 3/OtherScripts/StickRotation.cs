using UnityEngine;

public class StickRotation : MonoBehaviour
{
    [Tooltip("Rot rot speed in degrees per second")]
    public float speed = 360f;

    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
