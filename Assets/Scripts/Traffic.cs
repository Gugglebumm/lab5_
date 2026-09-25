using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Traffic : MonoBehaviour
{
    public float driveSpeed = 20f;
    public bool isActive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * driveSpeed * Time.deltaTime);
    }
}
