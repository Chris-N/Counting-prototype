using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    bool isShot = false;
    bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1 - SHOOT!");
            isShot = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3 - Jump!");
            isJump = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isShot)
        {
            Vector3 force1 = Vector3.back * (speed * 1.5f);
            Vector3 force2 = Vector3.up * (speed / 4);

            Vector3 result = force1 + force2;
            //rb.AddForce(force1, ForceMode.Impulse);
            //rb.AddForce(force2, ForceMode.Impulse);

            rb.AddForce(result, ForceMode.Impulse);
            isShot = false;
        }
        if (isJump)
        {
            Vector3 jump = Vector3.up;
            rb.AddForce(jump, ForceMode.Impulse);
            isJump = false;
        }

    }
}
