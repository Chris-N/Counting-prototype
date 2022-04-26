using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionController : MonoBehaviour
{
    GameManager gm;
    [SerializeField] ParticleSystem collisionParticle;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            Debug.Log("HIT! - Audio: boom");
            ParticleSystem ps = Instantiate(collisionParticle);
            ps.transform.position = gameObject.transform.position;
            collisionParticle.Play();
            gm.IncrementBallHitCount();
        }
    }
}
