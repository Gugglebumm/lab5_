using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Target Settings")]
    [Tooltip("The player or object the camera should follow.")]
    public Transform target;

    [Header("Camera Offset")]
    [Tooltip("Offset from the target's position.")]
    public Vector3 offset = new Vector3(0f, 5f, -10f);

    [Header("Follow Settings")]
    [Tooltip("How quickly the camera follows the target.")]
    [Range(0.01f, 1f)]
    public float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        // Ensure we have a target to follow
        if (target == null)
        {
            Debug.LogWarning("PlayerCameraFollow: No target assigned.");
            return;
        }

        // Desired position based on target + offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between current and desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply the smoothed position
        transform.position = smoothedPosition;

        // Optionally, keep looking at the target 
        transform.LookAt(target);
    }
}
