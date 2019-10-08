using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSearchlight : MonoBehaviour
{
    [SerializeField]
    private float fov;

    [SerializeField]
    private float searchDist;

    private int segments;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.03f;
        lineRenderer.positionCount = segments;
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
        lineRenderer.loop = true;
    }
    
    void Update()
    {
        segments = (int)Mathf.Max(Mathf.Ceil(fov / 10), 3);
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
}
