using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EasyUI.Toast;

public class Player : MonoBehaviour
{
    //Sequence aSequence;

    public Animator anim1;

    public Transform targetPosRot;

    private CharacterController charContr;

    public LayerMask groundLayers;

    public float jumpForce = 5f;

    public CapsuleCollider col;

    public Rigidbody rb;


    

    Spawner spawner;

    CoinTurn cnTurn;

    [SerializeField] public GameObject canvasObject;

    [SerializeField] private Force gm;
    [SerializeField] public bool jumpMe = false;

    private float sinValue = 0f;
    private float increment = 0.075f;
    private bool rotationStopped = false;
    [SerializeField] bool donuyorum = false;

    [SerializeField] Button powerButton;

    public LineRenderer lr;
    private Vector3[] positions = new Vector3[2];

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        powerButton = GameObject.FindGameObjectWithTag("PowerButton").GetComponent<Button>();
        powerButton.onClick.RemoveAllListeners();
        powerButton.onClick.AddListener(touchAndJump);

        lr = GetComponent<LineRenderer>();
        positions[0] = transform.position;
        positions[1] = transform.position + transform.forward * 5;
        lr.SetPositions(positions);

        //aSequence = DOTween.Sequence();

        GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();

        spawner = FindObjectOfType<Spawner>();

        gm = FindObjectOfType<Force>();

    }


    // Update is called once per frame
    void Update()
    {
        positions[0] = transform.position;
        positions[1] = transform.position + transform.forward * 5;
        lr.SetPositions(positions);
        if (donuyorum)
        {
            sinValue += increment;

            transform.localRotation = Quaternion.Euler(new Vector3(0, Mathf.Sin(sinValue) * 20, 0));
        }
    }

 


    public void touchAndJump()
    {

        

        if (donuyorum)
        {
            donuyorum = false;
            return;
        }

        jumpMe = true;

        if (jumpMe == true)
        {
            lr.positionCount = 0;
            jumpForce = gm.force;
            rb.velocity = Vector3.up * (jumpForce) * 2.3f + transform.forward * ((jumpForce) * 1.7f);

            anim1.Play("Floating");

            

            Debug.Log("animasyona girdi");
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        bool yürüdü = false;

        if(other.tag =="Spawn")
        {
            transform.DOMoveX(0, 2.5f);

            yürüdü = true;
            if (yürüdü == true)
            {
                Debug.Log("Yürüdü");
                //transform.DORotate(new Vector3(0, 90, 0), 0.5f, RotateMode.Fast);

                Debug.Log("döndü");
                //transform.DOLookAt(new Vector3(0, 0, 5.75f), 2f,AxisConstraint.None);
                Debug.Log("Done");
                
                anim1.SetBool("Idle", true);              

            }

        }

        else if (other.tag == "Finish" )
        {
            Debug.Log("buraya da girdi");

            Debug.DrawRay(transform.position, transform.forward * 10, Color.green);
            sinValue += increment;
            if (!rotationStopped)
            {
                donuyorum = true;
                Debug.Log("donuyorum degisti");
            }

        }

        else if(other.tag == null)
        {
            Destroy(gameObject, 3f);
        }

        else if(other.tag=="Died")
        {
            Destroy(GameObject.FindWithTag("Boy"));
            Debug.Log("destroyedd");
            spawner.SpawnJumper();

            

        }

        else if(other.tag == "Donkey" )
        {
            
            anim1.Play("Sitting");

            Handheld.Vibrate();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            
            jumpMe = false;
            Debug.Log("başarılı");

            
            spawner.SpawnJumper();

            
        }

        else if(other.tag == "Floor")
        {
            spawner.SpawnJumper();
            
            jumpMe = false;
            
            Debug.Log("yere degdi");
            anim1.Play("Dying");
            rb.constraints = RigidbodyConstraints.FreezeAll;
            

            this.enabled = false;
        }

        else if(other.tag == "Boy")
        {
            rb.velocity = Vector3.up * (jumpForce) * 0.4f + Vector3.forward * (jumpForce) * 0.2f;
        }

        else if(other.tag=="Down")

        {
            rb.velocity = Vector3.down * (jumpForce) * 1f;
        }

        

      
    }
    public bool isGrounded;

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }



    IEnumerator Wait()
    {
        Debug.Log("girdi");
        yield return new WaitForSecondsRealtime(2);
    }

    
}
