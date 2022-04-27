using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    [SerializeField] float _speedY = 0.5f;
    [SerializeField] float _speedZ = 3.0f;

    Rigidbody _rb;
    bool _hasFired = false;
    bool _isShot = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isShot && !_hasFired)
        {
            Vector3 force1 = Vector3.back * _speedZ;
            Vector3 force2 = Vector3.up * _speedY;

            Vector3 result = force1 + force2;
            _rb.AddForce(result, ForceMode.Impulse);
            _isShot = false;
            _hasFired = true;
        }
    }

    public void ToggleShot()
    {
        _isShot = !_isShot;
    }
}
