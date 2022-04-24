using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    bool isSwinging;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar - TORQUE: Audio swing!");
            isSwinging = true;
        }
    }

    void FixedUpdate()
    {
        if (isSwinging)
            Swing();
    }

    void Swing()
    {
        rb.AddRelativeTorque(Vector3.up * -speed, ForceMode.Impulse);
        isSwinging = false;
    }
}
