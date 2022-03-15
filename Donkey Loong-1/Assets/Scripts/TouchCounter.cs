using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyUI.Toast;
using DG.Tweening;

public class TouchCounter : MonoBehaviour
{

    CoinTurn cTurn;

    //public ParticleSystem jump;

    int countPlayer = 0;

    int deathCount = 0;

    public GameObject Panel;

    //int milliseconds = 2000;

    Player player1;

    public ParticleSystem sitParticle;

    public ParticleSystem floorParticle;

    public ShakerCamera shaker;

    public OddEvenn forODEVEN;

    public AudioSource winSound;

    AdManager reklamManager;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();

        forODEVEN = FindObjectOfType<OddEvenn>();

        winSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(deathCount>6)
        {
            reklamManager.GecisAD();
            SceneManager.LoadScene("GameOver");
        }

    }

    public void forPopUpScreen()
    {

        forODEVEN.WinStiuation();

        GameObject.FindGameObjectWithTag("Camera").transform.DOMoveZ(-5f,0.4f,true).OnComplete(()=>
        {
            GameObject.FindGameObjectWithTag("Camera").transform.DOMoveY(0f, 0.2f, true).OnComplete(() =>
            {
                GameObject.FindGameObjectWithTag("Camera").transform.DOMoveX(-5.6f, 0.1f, true);
            }
            );
        });
        
            winSound.Play(0);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Boy")
        {
            StartCoroutine(shaker.Shake(.15f,.4f));
            if (!sitParticle.isPlaying)
            {
                sitParticle.Play();
            }
            countPlayer++;

            if (countPlayer == 4)
            {
                
                forPopUpScreen();


            }

            Debug.Log("tutundu");
            //jump.Play();

        }

        else if(other.gameObject.tag=="Floor")
        {
            

            if (!floorParticle.isPlaying)
            {
                floorParticle.Play();
            }

            deathCount++;

            if(deathCount == 6)
            {
                StartCoroutine(forDeath());
            }
            
            Debug.Log("ölüyor");
            

        }


            
    }

    IEnumerator forDeath()
    {

        yield return new WaitForSeconds(2);
        reklamManager.rewardAD();
        SceneManager.LoadScene("GameOver");
    }

    /*public void PanelOpener()
    {
        bool isActive = Panel.activeSelf;
        Panel.SetActive(!isActive);
        Time.timeScale = 0;
    }
    */

}
