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

    public bool forFinish = false;

    public bool canVibrate = false;

    bool isVibrate = true;

    public ShakerCamera shaker;

    public ParticleSystem sitParticle;

    lauchParticle zıplamaEfekti;

    Spawner spawner;

    CoinTurn cnTurn;

    CoinPoints cp;

    //GameObject arrow;

    //GameObject quiver;

    GameObject powers;

    EsekAnim esek;

    ParticleSyst particlee;

    //GameObject camera1;

    //[SerializeField] GameObject force1;
    [SerializeField] GameObject skinObject;
    

    

    public Text yıkıldı;

    int countPlayer = 1;

    public bool forArrow2D = false;

    [SerializeField] public GameObject canvasObject;

    [SerializeField] private Force gm;
    [SerializeField] public bool jumpMe = false;

    private float sinValue = 0f;
    private float increment = 2f;
    private bool rotationStopped = false;
    [SerializeField] bool donuyorum = false;

    [SerializeField] Button powerButton;

    public int bump = 0;

    private Vector3[] positions = new Vector3[2];

    public int finish = 0;

    public OddEvenn forODEVEN;

    public AudioSource winSound;

    public GameObject forci;

    void Awake()
    {
        powerButton = GameObject.FindGameObjectWithTag("PowerButton").GetComponent<Button>();
        Debug.Log(skinObject.GetComponent<SkinnedMeshRenderer>().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Boy";

        DOTween.Init();

        GameObject.FindGameObjectWithTag("RotatingArrow").GetComponent<RotateArrow>().StartRotating();

        powerButton.onClick.RemoveAllListeners();
        powerButton.onClick.AddListener(touchAndJump);

        //lr = GetComponent<LineRenderer>();
        positions[0] = transform.position;
        positions[1] = transform.position + transform.forward * 5;
        //lr.SetPositions(positions);

        //aSequence = DOTween.Sequence();

        //GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

        spawner = FindObjectOfType<Spawner>();

        gm = FindObjectOfType<Force>();

        cp = FindObjectOfType<CoinPoints>();

        //arrow = GameObject.FindGameObjectWithTag("Arrow");

        //quiver = GameObject.FindGameObjectWithTag("Quiver");

        powers = GameObject.FindGameObjectWithTag("powerButon");

        
        forci = GameObject.FindGameObjectWithTag("Force");

        //force1.SetActive(false);

        esek = FindObjectOfType<EsekAnim>();

        particlee = FindObjectOfType<ParticleSyst>();

        forci.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
      
        

        positions[0] = transform.position;
        positions[1] = transform.position + transform.forward * 5;
        //lr.SetPositions(positions);
        if (donuyorum)
        {
            sinValue += increment * Time.deltaTime;


            //transform.localRotation = Quaternion.Euler(new Vector3(0, Mathf.Sin(sinValue) * 20, 0));
            Quaternion rotateArrowi = GameObject.FindGameObjectWithTag("RotatingArrow").transform.localRotation;
            //var rotatingArrow = GameObject.FindGameObjectWithTag("RotatingArrow").transform.localRotation;

            

            transform.localRotation = Quaternion.Euler(new Vector3(this.transform.localRotation.x, rotateArrowi.z * -100f, this.transform.localRotation.z));
        }

        
    }

    public void touchAndJump()
    {
        //quiver.SetActive(false);

        forci.SetActive(true);

        GameObject.FindGameObjectWithTag("Camera").transform.DOMoveY(5.4f, 0.3f, false);

        if (donuyorum)
        {
            donuyorum = false;
            GameObject.FindGameObjectWithTag("RotatingArrow").GetComponent<RotateArrow>().StopRotating();
            StartCoroutine(ButtonHider(1));
            return;
        }

        forci.SetActive(true);

        jumpMe = true;

        if (jumpMe == true || forFinish == true)
        {
            
            //lr.positionCount = 0;
            jumpForce = gm.force;

            rb.velocity = Vector3.up * (jumpForce) * 2f + transform.forward * ((jumpForce) * 2f);
            anim1.Play("JumpBoy");
            //anim1.SetBool("Jump", true);
            

            Destroy(GameObject.FindGameObjectWithTag("Arrow"));


            GameObject.FindGameObjectWithTag("Camera").transform.DOMoveY(10.5f, 0.2f, false).OnComplete(() =>
            {
                GameObject.FindGameObjectWithTag("Camera").transform.DOMoveZ(-15f, 0.4f, true).OnComplete(() =>
                  {
                      GameObject.FindGameObjectWithTag("Camera").transform.DOMoveZ(-27.62f, 0.3f, true);
                  });

            });
            
            //force1.SetActive(false);
            

            AudioManager.instance.Play("Jump");

            jumpMe = false;

            //quiver.SetActive(true);
            StartCoroutine(ButtonHider(1f));

            Debug.Log("animasyona girdi");

        }
        
    }

    private IEnumerator ButtonHider(float duration)
    {
        powerButton.enabled = false;

        yield return new WaitForSeconds(duration);
        powerButton.enabled = true;
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        bool yürüdü = false;

        

        if (other.tag == "Spawn")
        {
            GameObject.FindGameObjectWithTag("Camera").transform.DOMoveY(11f, 0.4f, true);

            forArrow2D = false;

            

            //quiver.SetActive(false);

            powers.SetActive(false);

            //force1.SetActive(true);

            GameObject.FindGameObjectWithTag("Camera").transform.DOMoveX(-4.5f, 1.5f);
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

        else if(other.tag == "jefrey")
        {
            forci.SetActive(false);
        }

        else if(other.tag == "true")
        {
            forci.SetActive(true);
        }

        else if (other.tag == "Finish")
        {



            //quiver.SetActive(true);

            powers.SetActive(true);

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

        else if (other.tag == null)
        {
            Destroy(gameObject, 3f);
        }

        else if (other.tag == "Died")
        {
            Destroy(GameObject.FindWithTag("Boy"));
            Debug.Log("destroyedd");

            Destroy(gameObject.GetComponent<CapsuleCollider>());
            spawner.SpawnJumper();

            

        }

        else if (other.tag == "Donkey")
        {

            forci.SetActive(false);

            if (canVibrate == true)
            {
                Handheld.Vibrate();
            }
            else
            {

            }

            

            anim1.Play("Sitting");

            AudioManager.instance.Play("Sit");

            Handheld.Vibrate();
            rb.constraints = RigidbodyConstraints.FreezeAll;

            jumpMe = false;
            Debug.Log("başarılı");


            spawner.SpawnJumper();

/*
            StartCoroutine(shaker.Shake(.15f, .4f));
            if (!sitParticle.isPlaying)
            {
                sitParticle.Play();
            }
            countPlayer++;

            if (countPlayer == 4)
            {

                forPopUpScreen();


            }

            Debug.Log("tutundu");  */
        }


        else if (other.tag == "Coin")
        {
            Debug.Log("serhat");
            Debug.Log("ÇARPTIIII" + other.transform.name);
            cp.coinIncrease();
            if (other.transform.name != "GoldTrigger")
            {
                Destroy(other.gameObject);
            }

        }

        else if (other.tag == "Floor")
        {
            forci.SetActive(false);

            particlee.particleee();
            

            spawner.SpawnJumper();

            finish++;

            if (finish == 3)
            {
                Debug.LogWarning("KAYBETTİN");
                StartCoroutine(Finish());
            }

            jumpMe = false;

            AudioManager.instance.Play("Sit");

            Debug.Log("yere degdi");
            anim1.Play("Dying");





            StartCoroutine(Floor());

            this.enabled = false;

        }

        else if (other.tag == "Freeze")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        else if (other.tag == "Boy")
        {
            rb.velocity = Vector3.up * (jumpForce) * 0.4f + Vector3.forward * (jumpForce) * 0.2f;
        }

        else if (other.tag == "Down")

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

    public void forPopUpScreen()
    {

        forODEVEN.WinStiuation();

        GameObject.FindGameObjectWithTag("Camera").transform.DOMove(new Vector3(0, 4, 2), 0.3f, false).OnComplete(() =>
        {
            GameObject.FindGameObjectWithTag("Camera").transform.DORotate(new Vector3(14.7f, 12, 0), 0.2f, RotateMode.Fast);
        });
        winSound.Play(0);
    }

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
        if(other.tag=="Finish")
        {
            //zıplamaEfekti.playParticle();
        }
    }

    IEnumerator Floor()
    {
        yield return new WaitForSeconds(1);
        rb.constraints = RigidbodyConstraints.FreezeAll;

        Destroy(gameObject.GetComponent<CapsuleCollider>());
    }


    IEnumerator Wait()
    {
        Debug.Log("girdi");
        yield return new WaitForSecondsRealtime(2);
    }

    IEnumerator Jumpi()
    {
        yield return new WaitForSeconds(0.3f);
        anim1.Play("Floating");
        
    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("GameOver");

    }


    IEnumerator Blowp()
    {
        //yıkıldı.gameObject.SetActive(true);
        Debug.Log("Yıkılmış olması lazım");
        particlee.particleee();
        
        yield return new WaitForSeconds(4);
        esek.BlowUp();
        Time.timeScale = 1;
        SceneManager.LoadScene("GameOver");
        
    }

   
}
