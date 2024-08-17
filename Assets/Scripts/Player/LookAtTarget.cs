using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;        //Reference to the target the player will look at

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
