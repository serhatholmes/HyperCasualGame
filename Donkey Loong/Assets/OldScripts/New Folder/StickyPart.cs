using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPart : MonoBehaviour
{
    [SerializeField] GameObject character;

    public Animator anim1;

    public Rigidbody rb;

    private CharacterController charcont;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Donkey" ||other.tag == "Cylinder")
        {

            FreezePlayer();

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Zombie"))
        {
            Debug.Log("Touched a rail");
            //rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    IEnumerator FreezePlayer()
    {
        anim1.Play("Sitting");
        yield return new WaitForSeconds(0.1f);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        
        rb.constraints = RigidbodyConstraints.FreezeRotation;
     }

}
