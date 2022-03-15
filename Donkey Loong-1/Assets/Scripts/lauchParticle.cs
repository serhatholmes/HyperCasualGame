using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lauchParticle : MonoBehaviour
{
    ParticleSystem launchParticle;

    // Start is called before the first frame update
    void Start()
    {
        launchParticle = GetComponent<ParticleSystem>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Boy")
        {
            launchParticle.Play();
        }
    }

    public void playParticle()
    {
        launchParticle.Play();
    }
}
