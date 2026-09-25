using UnityEngine;
using UnityEngine.InputSystem;

public class Catapult : MonoBehaviour
{
    public float rotationSpeed = 90f;

    public bool isActive = false;

    private Rigidbody catapultRb;
    private Rigidbody playerRb;

    void Start()
    {
        Debug.Log("Catapult is running");

        catapultRb = GetComponent<Rigidbody>();

        // Make sure the catapult is controlled by the script
        catapultRb.isKinematic = true;
        catapultRb.useGravity = false;
    }

    void Update()
    {
        // Press Q to activate/deactivate the catapult
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            isActive = !isActive;
        }
    }

    void FixedUpdate()
    {
        if (!isActive)
            return;

        // Rotate toward 90 degrees
        float newZ = Mathf.MoveTowardsAngle(
            catapultRb.rotation.eulerAngles.z,
            90f,
            rotationSpeed * Time.fixedDeltaTime
        );

        catapultRb.MoveRotation(
            Quaternion.Euler(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                newZ
            )
        );

        // When we reach 90 degrees, launch the player
        if (Mathf.Approximately(newZ, 90f))
        {
            LaunchPlayer();
            isActive = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRb = collision.gameObject.GetComponentInParent<Rigidbody>();
        }
    }

    void LaunchPlayer()
    {
        if (playerRb == null)
            return;

        // Launch the player in the direction the catapult is pointing
        Vector3 launchDirection = transform.up;

        float launchSpeed = rotationSpeed * Mathf.Deg2Rad;

        playerRb.linearVelocity = launchDirection * launchSpeed;
    }
}