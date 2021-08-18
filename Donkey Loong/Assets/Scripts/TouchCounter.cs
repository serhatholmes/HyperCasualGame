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

    int milliseconds = 2000;

    Player player1;

    public ParticleSystem sitParticle;

    public ParticleSystem floorParticle;

    public ShakerCamera shaker;

    public OddEvenn forODEVEN;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();

        forODEVEN = FindObjectOfType<OddEvenn>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(deathCount>6)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    public void forPopUpScreen()
    {
       
            forODEVEN.WinStiuation();

            GameObject.FindGameObjectWithTag("Camera").transform.DOMove(new Vector3(0, 4, 2), 0.3f, true).OnComplete(() =>
            {
                GameObject.FindGameObjectWithTag("Camera").transform.DORotate(new Vector3(15, 0, 0), 1.5f, RotateMode.Fast);

            });

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

            if (countPlayer == 2)
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


            
            Debug.Log("ölüyor");
            

        }


            
    }

    /*public void PanelOpener()
    {
        bool isActive = Panel.activeSelf;
        Panel.SetActive(!isActive);
        Time.timeScale = 0;
    }
    */

}
