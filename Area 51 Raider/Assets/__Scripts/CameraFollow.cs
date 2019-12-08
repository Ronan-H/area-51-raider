using UnityEngine;

// script to make the camera follow the player
public class CameraFollow : MonoBehaviour
{
    // transform to follow
    // settable through the editor
    [SerializeField]
    private Transform follow;

    // camera movement speed
    // settable through the editor
    [SerializeField]
    private float moveSpeed = 0.1f;

    // camera offset from the followed transform
    // settable through the editor
    [SerializeField]
    private Vector3 offset;


    void FixedUpdate()
    {
        // only follow if following Transform has been set
        if (follow != null)
        {
            // move towards follow transform
            Vector3 target = follow.position + offset;
            Vector3 interPosition = Vector3.Lerp(transform.position, follow.position, moveSpeed);
            interPosition.z = -10;
            transform.position = interPosition;
        }
    }
}
