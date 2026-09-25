using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatingObstacle : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public bool isActive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("RotatingObstacle is running");
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            isActive = !isActive;
        }//end if
        if (isActive)
        {
            float rotationThisFrame = rotationSpeed * Time.deltaTime;
            transform.Rotate(rotationThisFrame, 0f, 0f);
        }//end if
    }
}
