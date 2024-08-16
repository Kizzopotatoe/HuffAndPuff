using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector3 position;
    public float offset = 3f;

    // Update is called once per frame
    void Update()
    {
        position = Input.mousePosition;
        position.z = offset;
        transform.position = Camera.main.ScreenToWorldPoint(position);
    }
}
