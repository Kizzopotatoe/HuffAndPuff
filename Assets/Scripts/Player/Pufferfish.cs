using UnityEngine;

public class Pufferfish : MonoBehaviour
{
    private Rigidbody rb;       //Reference to the players rigidbody component

    private float horizontal;       //Stores horizontal movement variable
    public float speed;         //Stores movement speed value
    public bool bigMode;        //Boolean that checks if the player is in BIG MODE

    public float power;     //The current power of the players push
    public float basePower;     //The default power of the players push
    private Vector3 baseSize;       //The default size of the player character

    public LayerMask waterLayer;        //Reference to the water sorting layer

    public AudioSource source;      //Reference to the audio source component
    public AudioClip inhaleClip;        //Reference to the inhale audio clip
    public AudioClip exhaleClip;        //Reference to the exhale audio clip
    public AudioClip boing;         //Reference to the boing audio clip
    public AudioClip splash;        //Reference to the splash audio clip



    // Start is called before the first frame update
    void Start()
    {
        rb = FindObjectOfType<Rigidbody>();
        baseSize = transform.localScale;
        power = basePower;
        bigMode = false;
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
            source.PlayOneShot(exhaleClip);

            if(bigMode == true) return;

            transform.localScale = baseSize;
            power = basePower;
        }
    }

    //If the player holds the right mouse button and is in water, they will grow in size, increasing their push power
    void PuffUp()
    {
        if(Input.GetMouseButtonDown(1))
        {
            source.PlayOneShot(inhaleClip);
        }
        if(Input.GetMouseButton(1) && InWater())
        {
            if(power >= 14f && bigMode == false) return;
            if(power >=30f) return;
            transform.localScale *= 1.07f;
            power += 0.7f;
        }
    }

    //Creates a sphere at the center of the player character to check if they are currently in water, and returns a boolean
    private bool InWater()
    {
        return Physics.CheckSphere(this.transform.position, 0.5f, waterLayer);
    }

    //Collision audio, plays when the player collides with ground/ water
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            source.PlayOneShot(boing);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Water"))
        {
            source.PlayOneShot(splash);
        }

        if(other.gameObject.CompareTag("SuperWater"))
        {
            //When the player enters 'super water' big mode is enabled
            bigMode = true;

            source.PlayOneShot(splash);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Water"))
        {
            source.PlayOneShot(splash);
        }

        if(other.gameObject.CompareTag("SuperWater"))
        {
            source.PlayOneShot(splash);
        }
    }
}
