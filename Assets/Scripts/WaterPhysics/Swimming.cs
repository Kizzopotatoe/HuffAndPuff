using UnityEngine;

public class Swimming : MonoBehaviour
{
    private Rigidbody rb;       //Reference to the players rigidbody component

    // Start is called before the first frame update
    void Start()
    {
        rb = FindObjectOfType<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Water"))
        {
            rb.useGravity = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Water"))
        {
            rb.useGravity = true;
        }
    }
}
