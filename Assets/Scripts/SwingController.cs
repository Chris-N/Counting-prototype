using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject baseball;
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
            Debug.Log("Spacebar - TORQUE");
            isSwinging = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2 - Spawn ball");
            Instantiate(baseball, new Vector3(0.60f, 1.18f, 19.82f), baseball.transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("4 - Spawn jump ball");
            Instantiate(baseball, new Vector3(0.65f, 0.53f, 0.69f), baseball.transform.rotation);
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
