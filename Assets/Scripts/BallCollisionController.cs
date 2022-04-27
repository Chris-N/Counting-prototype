using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionController : MonoBehaviour
{
    [SerializeField] AudioClip _hitClip;
    [SerializeField] ParticleSystem _collisionParticle;
    [SerializeField] ParticleSystem _trailParticle;

    GameManager _gm;
    ParticleSystem _trailParticleInstance;
    AudioSource _audioPlayer;
    bool _isTrailParticleOn;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _audioPlayer = GameObject.Find("Global Audio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ClearResource();

        if (_isTrailParticleOn)
            _trailParticleInstance.transform.position = gameObject.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            _audioPlayer.PlayOneShot(_hitClip, 0.4f);
            _collisionParticle.transform.position = gameObject.transform.position;
            Instantiate(_collisionParticle);
            _collisionParticle.Play();

            _trailParticle.transform.position = gameObject.transform.position;
            _trailParticleInstance = Instantiate(_trailParticle);
            _trailParticleInstance.Play();
            _isTrailParticleOn = true;

            _gm.IncrementBallHitCount();
        }
    }
    private void ClearResource()
    {
        if(gameObject.transform.position.y < -20)
        {
            _isTrailParticleOn = false;
            if(_trailParticleInstance)
                Destroy(_trailParticleInstance.gameObject);
            Destroy(gameObject);
        }

    }
}
