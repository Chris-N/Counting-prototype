using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    AudioSource _swingAudio;
    Rigidbody _rb;
    bool _isSwinging;
    float _speed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = Vector3.zero;
        _swingAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _swingAudio.Play();
            _isSwinging = true;
        }
    }

    void FixedUpdate()
    {
        if (_isSwinging)
            Swing();
    }

    void Swing()
    {
        _rb.AddRelativeTorque(Vector3.up * -_speed, ForceMode.Impulse);
        _isSwinging = false;
    }
}
