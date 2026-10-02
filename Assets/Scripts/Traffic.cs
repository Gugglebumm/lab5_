using System;
using System.Collections;
using UnityEngine;

public class Traffic : MonoBehaviour
{
    public float driveSpeed = 20f;
    public bool isActive = true;

    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        // Remember where the car started
        startPosition = transform.position;
        startRotation = transform.rotation;

        // Start the repeating reset timer
        StartCoroutine(ResetCar());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * driveSpeed * Time.deltaTime);
    }

    IEnumerator ResetCar()
    {
        while (true)
        {
            // Wait 10 seconds
            yield return new WaitForSeconds(10f);

            // Reset the car
            transform.position = startPosition;
            transform.rotation = startRotation;
        }
    }
}