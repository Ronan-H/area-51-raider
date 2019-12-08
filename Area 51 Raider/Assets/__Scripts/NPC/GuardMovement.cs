using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardMovement : MonoBehaviour
{
    // angle/angle offset from where this guard is going
    // these are public so they can be accessed from the GuardSpotlight script
    public float angle;
    public float angleOffset;

    // allow setting of this guard's speed through the editor
    [SerializeField]
    private float speed;

    // list of waypoints that this guard will patrol
    // settable through the editor
    [SerializeField]
    private GameObject[] waypointObjects;
    // transforms extracted from the above waypoints
    private Transform[] waypoints;

    // waypoint that this guard show start (spawn) at
    [SerializeField]
    private int startIndex = 0;
    // waypoint (index) this guard is currently moving towards
    private int waypointIndex;

    // if set to true, the guard will visit it's list of waypoints in a random order
    // instead of going through them in order
    [SerializeField]
    private bool visitsWaypointsRandomly = false;

    // location of the player (for chasing/capture mechanics)
    private Transform playerTransform;

    void Start()
    {
        // find player transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (waypointObjects.Length > 0)
        {
            // extract transforms from the array of waypoints into a new array
            waypoints = new Transform[waypointObjects.Length];
            for (int i = 0; i < waypoints.Length; i++)
            {
                waypoints[i] = waypointObjects[i].transform;
            }

            if (visitsWaypointsRandomly)
            {
                // start at a random waypoint
                startIndex = UnityEngine.Random.Range(0, waypoints.Length);
            }

            // move gaurd to starting waypoint
            transform.position = waypointObjects[startIndex].transform.position;
            waypointIndex = startIndex;
        }
    }

    void Update()
    {
        if (GameState.PlayerSeen)
        {
            // player seen by a guard, chase him
            MoveTowardsTransform(playerTransform, Mathf.Clamp(speed * 2, 4, 7));

            if (Vector2.Distance(transform.position, playerTransform.position) < 0.8f)
            {
                // guard is close enough to player to capture him
                // restart level
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                GameState.ResetAll();
            }
        }
        else
        {
            if (waypointObjects.Length > 0)
            {
                // move towards current waypoint
                Transform currWaypoint = waypoints[waypointIndex];
                MoveTowardsTransform(currWaypoint, speed);

                if (Vector2.Distance(transform.position, currWaypoint.position) < 0.1f)
                {
                    // reached current waypoint, set next one
                    if (visitsWaypointsRandomly)
                    {
                        // next waypoint is random
                        waypointIndex = UnityEngine.Random.Range(0, waypoints.Length);
                    }
                    else
                    {
                        // next waypoint in the array (wraps around)
                        waypointIndex = (waypointIndex + 1) % waypoints.Length;
                    }
                }
            }
        }
    }

    // method for moving towards a point
    // (reused for both the player and the waypoints)
    private void MoveTowardsTransform(Transform t, float atSpeed)
    {
        // move towards
        transform.position = Vector2.MoveTowards(transform.position, t.position, atSpeed * Time.deltaTime);

        // compute x/y distances
        float yDist = t.position.y - transform.position.y;
        float xDist = t.position.x - transform.position.x;

        // find the angle the guard would need to be at to be facing the transform
        float targetAngle = Mathf.Atan2(yDist, xDist) * Mathf.Rad2Deg;

        // update guards angle (so he spins to face the transform)
        angle = Mathf.LerpAngle(angle, targetAngle, 0.02f);
        // find angle offset from transform (for GuardSearchlight script)
        angleOffset = Mathf.Clamp(1 - (Mathf.Abs(Mathf.DeltaAngle(angle, targetAngle)) / 90), 0.3f, 1);
    }
}
