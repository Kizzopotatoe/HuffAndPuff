using UnityEngine;

public class Pufferfish : MonoBehaviour
{
    private Rigidbody rb;
    public float power;
    public float basePower;
    private Vector3 baseSize;

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
        PuffUp();
    }

    void HuffOut()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.AddRelativeForce(0, 0, -power, ForceMode.Impulse);
            transform.localScale = baseSize;
            power = basePower;
        }
    }

    void PuffUp()
    {
        if(Input.GetMouseButton(1))
        {
            if(power >= 13f) return;
            transform.localScale *= 1.01f;
            power += 0.1f;
        }
    }
}
