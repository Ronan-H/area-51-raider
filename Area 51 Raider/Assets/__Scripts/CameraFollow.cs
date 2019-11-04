using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform follow;

    [SerializeField]
    private float moveSpeed = 0.1f;

    [SerializeField]
    private Vector3 offset;


    void FixedUpdate()
    {
        // only follow if following Transform has been set
        if (follow != null)
        {
            Vector3 target = follow.position + offset;
            Vector3 interPosition = Vector3.Lerp(transform.position, follow.position, moveSpeed);
            interPosition.z = -10;
            transform.position = interPosition;
        }
    }
}
