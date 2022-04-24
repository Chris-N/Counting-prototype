using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float speedY = 0.5f;
    [SerializeField] float speedZ = 3.0f;

    bool isShot = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1 - SHOOT!, Audio: shoot!");
            isShot = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isShot)
        {
            Vector3 force1 = Vector3.back * speedZ;
            Vector3 force2 = Vector3.up * speedY;

            Vector3 result = force1 + force2;
            rb.AddForce(result, ForceMode.Impulse);
            isShot = false;
        }
    }

    public void ToggleShot()
    {
        isShot = !isShot;
    }
}
