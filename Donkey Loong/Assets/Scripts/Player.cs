using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EasyUI.Toast;

public class Player : MonoBehaviour
{
    public int characterIndex;

    //Sequence aSequence;

    public Animator anim1;

    public Transform targetPosRot;

    private CharacterController charContr;

    public LayerMask groundLayers;

    public float jumpForce = 5f;

    public CapsuleCollider col;

    public Rigidbody rb;

    public bool forFinish = false;

    public bool canVibrate = false;

    bool isVibrate = true;

    bool isJumping = false;

    Spawner spawner;

    CoinTurn cnTurn;
    
    [SerializeField]
    GameObject arrow;

    GameObject quiver;

    GameObject powers;

    

    //GameObject camera1;

    GameObject force1;

    [SerializeField] public GameObject canvasObject;

    [SerializeField] private Force gm;
    [SerializeField] public bool jumpMe = false;

    private float sinValue = 0f;
    private float increment = 0.076f;
    private bool rotationStopped = false;
    [SerializeField] bool donuyorum = false;

    [SerializeField] Button powerButton;

    
    private Vector3[] positions = new Vector3[2];

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        powerButton = GameObject.FindGameObjectWithTag("PowerButton").GetComponent<Button>();
        powerButton.onClick.RemoveAllListeners();
        powerButton.onClick.AddListener(touchAndJump);

        //lr = GetComponent<LineRenderer>();
        positions[0] = transform.position;
        positions[1] = transform.position + transform.forward * 5;
        //lr.SetPositions(positions);

        //aSequence = DOTween.Sequence();

        GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();

        spawner = FindObjectOfType<Spawner>();

        gm = FindObjectOfType<Force>();

        arrow.SetActive(true);

        // quiver= GameObject.FindGameObjectWithTag("Quiver");

        //powers = GameObject.FindGameObjectWithTag("powerButon");

        //force1 = GameObject.FindGameObjectWithTag("Force");

        arrow.SetActive(false);

        //force1.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        positions[0] = transform.position;
        positions[1] = transform.position + transform.forward * 5;
        //lr.SetPositions(positions);
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

        if (jumpMe == true || forFinish == true)
        {


            StartCoroutine(jumping());


            //force1.SetActive(false);

            AudioManager.instance.Play("Jump");
            anim1.Play("Floating");

            jumpMe = false;

            

            

            Debug.Log("animasyona girdi");


        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        bool y??r??d?? = false;

        if(other.tag =="Spawn")
        {
            

            arrow.SetActive(false);

            //quiver.SetActive(false);

            //SetActive(false);

            //force1.SetActive(true);

            GameObject.FindGameObjectWithTag("Camera").transform.DOMoveX(-6.82f,2f);
            transform.DOMoveX(0, 2.5f);

            y??r??d?? = true;
            if (y??r??d?? == true)
            {
                Debug.Log("Y??r??d??");
                //transform.DORotate(new Vector3(0, 90, 0), 0.5f, RotateMode.Fast);

                Debug.Log("d??nd??");
                //transform.DOLookAt(new Vector3(0, 0, 5.75f), 2f,AxisConstraint.None);
                Debug.Log("Done");
                
                anim1.SetBool("Idle", true);              

            }

        }

        else if (other.tag == "Finish" )
        {
            //GameObject.FindGameObjectWithTag("Arrow").SetActive(true);

            arrow.SetActive(true);

            //quiver.SetActive(true);

            //powers.SetActive(true);

            forFinish = true;

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
            Destroy(gameObject.GetComponent<CapsuleCollider>());
            spawner.SpawnJumper();

            //force1.SetActive(true);

        }

        else if(other.tag == "Donkey" )
        {
            


            if (canVibrate==true)
            {
                Handheld.Vibrate();
            }
            else
            {

            }

            //force1.SetActive(true);

            anim1.Play("Sitting");

            AudioManager.instance.Play("Sit");

            Handheld.Vibrate();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            
            jumpMe = false;
            Debug.Log("ba??ar??l??");

            
            spawner.SpawnJumper();

            
        }

        else if(other.tag == "Floor")
        {
            //force1.SetActive(true);

            spawner.SpawnJumper();
            
            jumpMe = false;

            AudioManager.instance.Play("Sit");

            Debug.Log("yere degdi");
            anim1.Play("Dying");

            

            
            
            rb.constraints = RigidbodyConstraints.FreezeAll;

            Destroy(gameObject.GetComponent<CapsuleCollider>());

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

        else if (other.tag == "Wait")
        {
            forFinish = false;
            jumpMe = false;
        }



    }
    public bool isGrounded;

    public void VibrationMute()
    {
        if (isVibrate == true)
        {
            Debug.Log("vibration is on");
            canVibrate = true;
            isVibrate = false;
        }
        else
        {
            Debug.Log("vibration is off");
            canVibrate = false;
            isVibrate = true;
        }
    }

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

    IEnumerator jumping()
    {
        //lr.positionCount = 0;
        GameObject.FindGameObjectWithTag("Camera").transform.DOMoveY(6, 0.5f);
        jumpForce = gm.force;
        rb.velocity = Vector3.up * (jumpForce) * 2f + transform.forward * ((jumpForce) * 2f);
        isJumping = true;
        
            
        anim1.Play("JumpBoy");
        

        

       // GameObject.FindGameObjectWithTag("Arrow").SetActive(false);


        GameObject.FindGameObjectWithTag("Camera").transform.DOMoveY(8.92f, 0.5f).OnComplete(()=>
        {
            GameObject.FindGameObjectWithTag("Camera").transform.DOMoveZ(-13, 0.5f).OnComplete(() =>
             {
                 GameObject.FindGameObjectWithTag("Camera").transform.DOMoveZ(-22.24f, 0.5f).OnComplete(() =>
                 {
                     GameObject.FindGameObjectWithTag("Camera").transform.DOMove(new Vector3(-7.8f, 8.93f, -22.24f), 1f, false);
                 });

             });
        }

        );
        yield return new WaitForSeconds(0.5f);
    }
}
