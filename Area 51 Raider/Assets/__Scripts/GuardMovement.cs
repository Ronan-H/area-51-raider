using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardMovement : MonoBehaviour
{
    public float angle;
    public float angleOffset;

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject[] waypointObjects;

    private Transform playerTransform;

    [SerializeField]
    private int startIndex = 0;

    private Rigidbody2D rb2d;
    private Transform[] waypoints;
    private int waypointIndex;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        rb2d = GetComponent<Rigidbody2D>();
        waypoints = new Transform[waypointObjects.Length];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }

        transform.position = waypointObjects[startIndex].transform.position;
        waypointIndex = startIndex;
    }

    void Update()
    {
        if (GameState.PlayerSeen)
        {
            MoveTowardsTransform(playerTransform, 2);

            if (Vector2.Distance(transform.position, playerTransform.position) < 1.2f)
            {
                SceneManager.LoadScene(sceneName: "Level1");
            }
        }
        else
        {
            Transform currWaypoint = waypoints[waypointIndex];
            MoveTowardsTransform(currWaypoint, 1);

            if (Vector2.Distance(transform.position, currWaypoint.position) < 0.1f)
            {
                waypointIndex = (waypointIndex + 1) % waypoints.Length;
            }
        }
    }

    private void MoveTowardsTransform(Transform t, float speedModifier)
    {
        transform.position = Vector2.MoveTowards(transform.position, t.position, speed * Time.deltaTime * speedModifier);

        float yDist = t.position.y - transform.position.y;
        float xDist = t.position.x - transform.position.x;

        float targetAngle = Mathf.Atan2(yDist, xDist) * Mathf.Rad2Deg;

        angle = Mathf.LerpAngle(angle, targetAngle, 0.02f);

        angleOffset = Mathf.Clamp(1 - (Mathf.Abs(Mathf.DeltaAngle(angle, targetAngle)) / 90), 0.3f, 1);
    }
}
