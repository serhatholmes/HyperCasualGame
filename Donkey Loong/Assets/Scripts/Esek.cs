using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Esek : MonoBehaviour
{
    int counter = 0;

    void Start()
    {
        GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Boy"))
            {
                counter++;
            }
    }
}
