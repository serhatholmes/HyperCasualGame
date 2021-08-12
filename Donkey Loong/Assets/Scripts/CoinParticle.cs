using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParticle : MonoBehaviour
{
    ParticleSystem coinParticle;

    void Start()
    {
        coinParticle = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boy")
        {
           
                coinParticle.Play();
                Destroy(gameObject.GetComponent<SphereCollider>());

        }
    }
}
