using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class EsekAnim : MonoBehaviour
{
    public CapsuleCollider coll;

    Animator anim2;

    public bool isIt = false;

    Rigidbody rb;

    public int countClick = 0;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        
       anim2 = GetComponent<Animator>();

        coll = GetComponent<CapsuleCollider>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(countClick==20)
        {
            
        }
    }

    public void playAnimation()
    {
        anim2.SetBool("dead", true);
        isIt = true;
    }


    public void BlowUp()
    {
        rb.transform.DOMoveX(-2, 0.5f);
        rb.velocity = Vector3.up * 1.5f;
        anim2.Play("GirlFall");
        GameObject.FindGameObjectWithTag("Camera").transform.DOMove(new Vector3(-1.71f, 4.6f, 1f), 0.3f, true);
        
    }

    public void ButtonClickCount()
    {
        countClick++;
    }

}
