using UnityEngine;

public class CompensateRotation : MonoBehaviour
{
    void Update()
        {
            Vector3 self = transform.rotation.eulerAngles;
            gameObject.transform.rotation = Quaternion.Euler(self.x, self.y, 0); 
        }
}
