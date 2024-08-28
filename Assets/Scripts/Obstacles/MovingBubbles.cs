using UnityEngine;

public class MovingBubbles : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float checkDistance = 0.05f;

    private Transform targetWaypoint;
    private int currentWaypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        targetWaypoint = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
    
        if(Vector2.Distance(transform.position, targetWaypoint.position) < checkDistance)
        {
            targetWaypoint = GetNextWaypoint();
        }
    }

    //Returns the transform component of the next waypoint in the array
    private Transform GetNextWaypoint()
    {
        currentWaypointIndex++;
        if(currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }

        return waypoints[currentWaypointIndex];
    }
}
