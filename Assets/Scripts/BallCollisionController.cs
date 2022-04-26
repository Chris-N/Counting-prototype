using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionController : MonoBehaviour
{
    GameManager gm;
    [SerializeField] ParticleSystem collisionParticle;
    [SerializeField] ParticleSystem trailParticle;
    ParticleSystem trailParticleInstance;

    bool isTrailParticleOn;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ClearResource();

        if (isTrailParticleOn)
            trailParticleInstance.transform.position = gameObject.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            Debug.Log("HIT! - Audio: boom");
            collisionParticle.transform.position = gameObject.transform.position;
            Instantiate(collisionParticle);
            collisionParticle.Play();

            trailParticle.transform.position = gameObject.transform.position;
            trailParticleInstance = Instantiate(trailParticle);
            trailParticleInstance.Play();
            isTrailParticleOn = true;

            gm.IncrementBallHitCount();
        }
    }
    private void ClearResource()
    {
        if(gameObject.transform.position.y < -20)
        {
            isTrailParticleOn = false;
            if(trailParticleInstance)
                Destroy(trailParticleInstance.gameObject);
            Destroy(gameObject);
        }

    }
}
