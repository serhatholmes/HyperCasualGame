using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSyst : MonoBehaviour
{
    ParticleSystem sitPart;



    void Start()
    {
        sitPart = GetComponent<ParticleSystem>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boy")
        {
            sitPart.Play();
        }

    }

    void buttonParticle()
    {
        
    }

    public void particleee()
    {
        sitPart.Play();
    }
}
