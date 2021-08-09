using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour //, IPointerDownHandler
{
    //[SerializeField] private Cinematic cine;
    [SerializeField] private float jumpSpeed = 4.0f;
    [SerializeField] private GameObject ragdoll;
    [SerializeField] private GameObject animated;
    [SerializeField] private Animator anim;
    [SerializeField] private Spawner spawner;
    [SerializeField] private Force gm;
    private Rigidbody rb;
    private bool rotationStopped = false;
    private bool jumping = false;
    //private float rotationSpeed = 720f;
    private float sinValue = 0f;
    private float increment = 0.04f;
    //private FollowerArrow fArrow;

    // Start is called before the first frame update

    private void Awake()
    {
        ragdoll.SetActive(false);
        animated.SetActive(true);
        gm = FindObjectOfType<Force>();
        spawner = FindObjectOfType<Spawner>();
    }

    void Start()
    {
        

        rb = GetComponent<Rigidbody>();
        jumping = false;
        //cine.DoIt();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name); 
        if (jumping)
        {
            if (other.gameObject.tag == "Donkey" || other.gameObject.tag == "Floor")
            {
                //gm.UpdateScore();
                spawner.SpawnJumper();
                jumping = false;
                this.enabled = false;
            }
            if(other.gameObject.tag =="Donkey")
            {
                gm.UpdateScore();
                anim.Play("Sitting");
            }
            
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //OnBecameInvisible();

        Debug.DrawRay(transform.position, transform.forward * 50,Color.green);
        sinValue += increment;
        if (!rotationStopped)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, Mathf.Sin(sinValue) * 40, 0));
            
        }

            

             if (Input.GetButtonDown("Fire1"))
                {
                    if (rotationStopped)
                        {
                            StartCoroutine("JumpAction");
                            Destroy(GameObject.FindGameObjectWithTag("Arrow"));
                        }
                     else
                        {
                        rotationStopped = true;
                        //rotationSpeed = 0f; 
                        }

            }

        
        if (Input.GetKeyDown(KeyCode.C))
        {
            animated.SetActive(false);
            ragdoll.SetActive(true);
            CopyPosRotVel(animated, ragdoll);
            Destroy(GameObject.FindGameObjectWithTag("Arrow"));
            
        }
    }

    private void CopyPosRotVel(GameObject A, GameObject B)
    {
        if (A.transform.childCount != B.transform.childCount)
        {
            return;
        }
        else
        {
            for (int i=0; i<A.transform.childCount; i++)
            {
                var a = A.transform.GetChild(i);
                var b = B.transform.GetChild(i);
                b.position = a.position;
                b.rotation = a.rotation;
                var b_rb = b.GetComponent<Rigidbody>();
                if (b_rb)
                {
                    b_rb.velocity = rb.velocity;
                }
                CopyPosRotVel(a.gameObject, b.gameObject);
            }
        }
    }

    private IEnumerator JumpAction()
    {
        anim.SetBool("Jumping", true);
        
        jumpSpeed = gm.force;
        yield return new WaitForSeconds(0.001f);


        rb.velocity = Vector3.up * (jumpSpeed)*0.85f + transform.forward * ((jumpSpeed)*1.01f);
       
        //anim.SetBool("Jumping", false);
        //anim.SetBool("Sitting", true);
        animated.SetActive(false);
        ragdoll.SetActive(true);

        CopyPosRotVel(animated, ragdoll);
        jumping = true;
    }

   

    /*void OnBecameInvisible()
    {
        Destroy(gameObject);
    }  */
}
