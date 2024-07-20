using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaticelController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;
    [Range(0,10)]
    [SerializeField] int accurAfterVelocity;

    [Range(0,0.02f)]
    [SerializeField] float dustFormationPerod;

    [SerializeField] Rigidbody2D playerRB;

    float counter;

    private void Update() 
    {
        counter += Time.deltaTime;
        if (Mathf.Abs(playerRB.velocity.x) > accurAfterVelocity)
        {
            if (counter > dustFormationPerod)
            {
                movementParticle.Play();
                counter = 0;
            }
        }
    }
}
