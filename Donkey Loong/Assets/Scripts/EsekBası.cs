using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsekBası : MonoBehaviour
{

    Rigidbody rb1;

    CapsuleCollider cap;

    // Start is called before the first frame update
    void Start()
    {
        cap = GetComponent<CapsuleCollider>();

        rb1 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Boy")
        {
            rb1.velocity = Vector3.up * 1f;
        }
    }

    
}
