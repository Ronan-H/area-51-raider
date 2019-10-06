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
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }
}
