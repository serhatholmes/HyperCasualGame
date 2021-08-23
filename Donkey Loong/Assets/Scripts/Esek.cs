using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class Esek : MonoBehaviour
{
    int counter = 0;

    EsekAnim forAnim;

    public bool dead = false;

    

    public bool forRB = false;

    void Start()
    {
        DOTween.Init();

        forAnim = FindObjectOfType<EsekAnim>();
    }

    void Update()
    {
        if(counter==3)
        {
            if(forRB==true)
            {
                transform.DOMoveY(0.9f, 0.2f);
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
            }

        if(other.gameObject.tag == ("Floor"))
            {
            
                forAnim.playAnimation();
                dead = true;
                Debug.Log("sonra");
        }
    }


}
