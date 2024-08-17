using UnityEngine;
using UnityEngine.Rendering;

public class Pufferfish : MonoBehaviour
{
    private Rigidbody rb;       //Reference to the players rigidbody component

    private float horizontal;       //Stores horizontal movement variable
    public float speed;         //Stores movement speed value

    public float power;     //The current power of the players push
    public float basePower;     //The default power of the players push
    private Vector3 baseSize;       //The default size of the player character

    public LayerMask waterLayer;        //Reference to the water sorting layer


    // Start is called before the first frame update
    void Start()
    {
        rb = FindObjectOfType<Rigidbody>();
        baseSize = transform.localScale;
        power = basePower;
    }

    // Update is called once per frame
    void Update()
    {
        HuffOut();

        horizontal = Input.GetAxisRaw("Horizontal");
        rb.AddForce(horizontal * speed, 0, 0);
    }
    void FixedUpdate()
    {
        PuffUp();
    }

    //If the player presses the left mouse button, they will launch backwards proportional to their push power, and return to their base size
    void HuffOut()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.AddRelativeForce(0, 0, -power, ForceMode.Impulse);
            transform.localScale = baseSize;
            power = basePower;
        }
    }

    //If the player holds the right mouse button and is in water, they will grow in size, increasing their push power
    void PuffUp()
    {
        if(Input.GetMouseButton(1) && InWater())
        {
            if(power >= 13f) return;
            transform.localScale *= 1.1f;
            power += 1f;
        }
    }

    //Creates a sphere at the center of the player character to check if they are currently in water, and returns a boolean
    private bool InWater()
    {
        return Physics.CheckSphere(this.transform.position, 0.5f, waterLayer);
    }
}
