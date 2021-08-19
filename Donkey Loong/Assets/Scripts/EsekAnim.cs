using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EsekAnim : MonoBehaviour
{
    public CapsuleCollider coll;

    public Animator anim2;

    public bool isIt = false;

    

    // Start is called before the first frame update
    void Start()
    {
       anim2 = GetComponent<Animator>();

        coll = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAnimation()
    {
        anim2.SetBool("dead", true);
        isIt = true;
    }
}
