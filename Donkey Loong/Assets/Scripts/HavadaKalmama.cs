using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class HavadaKalmama : MonoBehaviour
{
    public bool onAir = false;

    [SerializeField] public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Donkey")
        {
            onAir = false;
            isOnAir();
        }
        else if(other.gameObject.tag == "Floor")
        {
            onAir = false;
            isOnAir();
        }
        else if(other.gameObject.tag == "Died")
        {
            onAir = false;
            isOnAir();
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            onAir= true;
            
        }
    }

    IEnumerator Waiit()
    {
        Debug.Log("havada");
        yield return new WaitForSecondsRealtime(3);
    }


    public void isOnAir()
    {
        if (onAir == true)
        {
            Thread.Sleep(100);
            rb.velocity = Vector3.up * 2f + transform.right * 1f;
        }
    }
}
