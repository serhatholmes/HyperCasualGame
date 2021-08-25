using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Esek : MonoBehaviour
{
    int counter = 0;

    EsekAnim forAnim;

    public bool dead = false;

    ParticleSyst particleee;

    public bool forRB = false;

    //float timer = 0;

    void Start()
    {
        DOTween.Init();

        //particleee = GetComponent<ParticleSyst>();

        forAnim = FindObjectOfType<EsekAnim>();
    }

    void Update()
    {
        

        /*void OnGUI()
        {
            if(timer < 5)
            {
                GUI.Label
            }
        } */

        if(counter==2)
        {
            if(forRB==true)
            {
                transform.DOMoveY(0.5f, 0.2f);
            }

            if(dead==true)
            {
                SceneManager.LoadScene("GameOver");
            }
            
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Boy"))
            {
                counter++;
                forRB = true;
                Debug.Log("önce");

                if(counter==3)
                {
                Debug.Log("Yıkılmış olması lazım");
                //particleee.particleee();
                StartCoroutine(DownDead());
                
                
                }
            }

       
    }

    IEnumerator DownDead()
    {
        
        forAnim.BlowUp();
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("WinScene");
    }


}
