using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionController : MonoBehaviour
{
    GameManager gm;
    [SerializeField] ParticleSystem collisionParticle;
    [SerializeField] ParticleSystem trailParticle;
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
        {

        }
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
            Instantiate(trailParticle);
            trailParticle.Play();
            isTrailParticleOn = true;

            gm.IncrementBallHitCount();
        }
    }
    private void ClearResource()
    {
        if(gameObject.transform.position.y < 0)
        {
            isTrailParticleOn = false;
            Destroy(gameObject);
        }

    }
}
