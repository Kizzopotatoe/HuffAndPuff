using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector3 position;       //Vector 3 to store the position of the mouse
    public float offset = 10f;      //How far is the object offset from the camera
    public Pufferfish pufferfish;

    // Start is called before the first frame update
    void Start()
    {
        pufferfish = FindObjectOfType<Pufferfish>();
    }

    // Update is called once per frame
    void Update()
    {
        position = Input.mousePosition;
        position.z = offset;
        transform.position = Camera.main.ScreenToWorldPoint(position);

        if(pufferfish.bigMode == true)
        {
            offset = 30f;
        }
    }
}
