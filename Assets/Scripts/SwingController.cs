using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar - TORQUE");
            rb.AddRelativeTorque(Vector3.up * -speed, ForceMode.Impulse);
        }
    }
}
