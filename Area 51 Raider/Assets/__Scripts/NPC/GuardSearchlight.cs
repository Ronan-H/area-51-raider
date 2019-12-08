using System.Collections.Generic;
using UnityEngine;

public class GuardSearchlight : MonoBehaviour
{
    // guard field of view
    // settable through the editor
    [SerializeField]
    private float fov;

    // guard base search distance
    // settable through the editor
    [SerializeField]
    private float baseSearchDist;
    // current search distance
    private float searchDist;

    // number of line segments (similar to raycast) to use for this guard's searchlight
    // (computed at runtime based on FOV)
    private int segments;

    // set to true if this guard is in a dark area
    // (so their search distance is reduced if the player has
    // found the cloak item)
    [SerializeField]
    private bool inDarkArea = false;

    // used to draw lines (to render the searchlight)
    private LineRenderer lineRenderer;
    // used to check if the player is visible from this searchlight
    private PlayerMovement playerMovement;
    private PlayerBox playerBox;

    void Start()
    {
        // initialise LineRenderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.05f;
        lineRenderer.positionCount = segments;
        lineRenderer.loop = true;

        // find player components
        GameObject player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerBox = player.GetComponent<PlayerBox>();

        // reduce search distance if this guard is in the dark
        // and the player has found the cloak item
        if (inDarkArea && PlayerItems.HasItem("Cloak"))
        {
            baseSearchDist /= 2f;
        }
    }
    
    void Update()
    {
        // number of line segments to use for collision detection (based on FOV)
        segments = (int)Mathf.Max(Mathf.Ceil(fov / 3), 3);
        // current search distance (lower if the guard is turning)
        searchDist = baseSearchDist * gameObject.GetComponent<GuardMovement>().angleOffset;
        // draw the guard's searchlight
        DrawSearchlight();
    }

    void DrawSearchlight()
    {
        // create list of points to draw
        List<Vector2> arcPoints = new List<Vector2>();
        float guardAngle = gameObject.GetComponent<GuardMovement>().angle;
        float currAngle;
        // first point is where the guard currently is
        arcPoints.Add(transform.position);
        // create list of points out in an arc around the guard
        for (int i = 0; i <= segments; i++)
        {
            // compute new angle
            currAngle = guardAngle
                  + (fov / 2)
                  - i * (fov / segments);

            // find x/y coordinate from angle and search distance
            float x = transform.position.x + Mathf.Cos(Mathf.Deg2Rad * currAngle) * searchDist;
            float y = transform.position.y + Mathf.Sin(Mathf.Deg2Rad * currAngle) * searchDist;

            // add point to list
            arcPoints.Add(new Vector2(x, y));
        }

        // connect a line between each of these points
        lineRenderer.positionCount = arcPoints.Count;
        for (int i = 0; i < arcPoints.Count; i++) {
            lineRenderer.SetPosition(i, arcPoints[i]);
        }
    }

    void FixedUpdate()
    {
        if (CanSeePlayer())
        {
            // update global variable to let other guards know the player has been spotted
            GameState.PlayerSeen = true;
            // loop the siren sound effect (if it's not already looping)
            GameObject.FindObjectOfType<SoundManager>().LoopSiren();
        }

        if (GameState.PlayerSeen)
        {
            // searchlight color is red when player has been seen
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;
        }
        else
        {
            // searchlight color is yellow when player has not been seen
            lineRenderer.startColor = Color.yellow;
            lineRenderer.endColor = Color.yellow;
        }
    }

    // returns true if this guard can see the player
    bool CanSeePlayer()
    {
        if (playerBox.inBox && Mathf.Abs(Input.GetAxis("Horizontal")) <= 0.2 && Mathf.Abs(Input.GetAxis("Vertical")) <= 0.2)
        {
            // player is in a box and not moving, he cannot be seen
            return false;
        }

        // use linecasts to check if the guard can see the player
        float guardAngle = gameObject.GetComponent<GuardMovement>().angle;
        float currAngle;
        for (int i = 0; i <= segments; i++)
        {
            // compute new angle
            currAngle = guardAngle
                  + (fov / 2)
                  - i * (fov / segments);

            Vector2 rayAngle = new Vector2(Mathf.Cos(currAngle * Mathf.Deg2Rad), Mathf.Sin(currAngle * Mathf.Deg2Rad));

            // find x/y components of where the linecast ends
            float toX = transform.position.x + Mathf.Cos(Mathf.Deg2Rad * currAngle) * searchDist;
            float toY = transform.position.y + Mathf.Sin(Mathf.Deg2Rad * currAngle) * searchDist;
            Vector2 lineTo = new Vector2(toX, toY);
            // create hit object
            RaycastHit2D hit = Physics2D.Linecast(transform.position, lineTo);

            // draw linecast for debugging purposes
            Debug.DrawLine(transform.position, lineTo);

            if (hit.collider != null && hit.collider.gameObject.tag == "Player")
            {
                // player hit with raycast; player has been spotted
                return true;
            }
        }

        // player not spotted by linecast
        return false;
    }
}
