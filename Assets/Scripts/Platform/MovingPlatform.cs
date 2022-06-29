using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2.0f;
    private int currentWaypoint;

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < 0.1f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currentWaypoint].transform.position,
            speed * Time.deltaTime);
    }
}