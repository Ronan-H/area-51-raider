using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSearchlight : MonoBehaviour
{
    [SerializeField]
    private float fov;

    [SerializeField]
    private float baseSearchDist;

    private float searchDist;

    private int segments;

    private LineRenderer lineRenderer;

    private PlayerMovement playerMovement;
    private PlayerBox playerBox;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.positionCount = segments;
        lineRenderer.loop = true;

        GameObject player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerBox = player.GetComponent<PlayerBox>();
    }
    
    void Update()
    {
        segments = (int)Mathf.Max(Mathf.Ceil(fov / 8), 3);
        searchDist = baseSearchDist * gameObject.GetComponent<GuardMovement>().angleOffset;
        DrawSearchlight();
    }

    void DrawSearchlight()
    {
        List<Vector2> arcPoints = new List<Vector2>();
        float guardAngle = gameObject.GetComponent<GuardMovement>().angle;
        float currAngle;
        arcPoints.Add(transform.position);
        for (int i = 0; i <= segments; i++)
        {
            currAngle = guardAngle
                  + (fov / 2)
                  - i * (fov / segments);

            float x = transform.position.x + Mathf.Cos(Mathf.Deg2Rad * currAngle) * searchDist;
            float y = transform.position.y + Mathf.Sin(Mathf.Deg2Rad * currAngle) * searchDist;

            arcPoints.Add(new Vector2(x, y));
        }

        lineRenderer.positionCount = arcPoints.Count;
        for (int i = 0; i < arcPoints.Count; i++) {
            lineRenderer.SetPosition(i, arcPoints[i]);
        }
    }

    void FixedUpdate()
    {
        if (CanSeePlayer())
        {
            GameState.PlayerSeen = true;
        }

        if (GameState.PlayerSeen)
        {
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;
        }
        else
        {
            lineRenderer.startColor = Color.yellow;
            lineRenderer.endColor = Color.yellow;
        }
    }

    bool CanSeePlayer()
    {
        if (playerBox.inBox && playerMovement.rb2d.velocity.magnitude < 0.5)
        {
            return false;
        }

        float guardAngle = gameObject.GetComponent<GuardMovement>().angle;
        float currAngle;
        for (int i = 0; i <= segments; i++)
        {
            currAngle = guardAngle
                  + (fov / 2)
                  - i * (fov / segments);

            Vector2 rayAngle = new Vector2(Mathf.Cos(currAngle * Mathf.Deg2Rad), Mathf.Sin(currAngle * Mathf.Deg2Rad));

            float toX = transform.position.x + Mathf.Cos(Mathf.Deg2Rad * currAngle) * searchDist;
            float toY = transform.position.y + Mathf.Sin(Mathf.Deg2Rad * currAngle) * searchDist;
            Vector2 lineTo = new Vector2(toX, toY);
            RaycastHit2D hit = Physics2D.Linecast(transform.position, lineTo);

            Debug.DrawLine(transform.position, lineTo);

            if (hit.collider != null && hit.collider.gameObject.tag == "Player")
            {
                return true;
            }
        }

        return false;
    }
}
