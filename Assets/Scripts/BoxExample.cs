using UnityEngine;

public class BoxExample : MonoBehaviour
{
    public float forceAmount = 5f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * forceAmount);
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collision with: " + collision.gameObject.name);
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger: " + other.gameObject.name);
    }
}
