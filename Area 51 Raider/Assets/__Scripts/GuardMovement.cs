using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject[] waypointObjects;

    private Rigidbody2D rb2d;
    private Transform[] waypoints;
    private int waypointIndex;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        waypoints = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }
    }

    void Update()
    {
        Transform currWaypoint = waypoints[waypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, currWaypoint.position, speed * Time.deltaTime);

        float yDist = currWaypoint.position.y - transform.position.y;
        float xDist = currWaypoint.position.x - transform.position.x;

        float newAngle = Mathf.Atan2(yDist, xDist) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, newAngle));

        if (Vector2.Distance(transform.position, currWaypoint.position) < 0.1f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }
}
