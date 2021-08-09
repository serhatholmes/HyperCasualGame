using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using EasyUI.Toast;

public class Ayrılma : MonoBehaviour
{

    

    

    public float force = 5f;

    Rigidbody rb1;

    CapsuleCollider cap;

    public bool rode = false;

    public int howMany = 0;

    int countBoy = 0;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();

        cap = GetComponent<CapsuleCollider>();

        rb1 = GetComponent<Rigidbody>();



    }

    // Update is called once per frame
    void Update()
    {
        if (rode == true)
        {
            if (countBoy == 1)
            {
                rb1.velocity = Vector3.left * 1;
                
                StartCoroutine("Waitt");
                

            }
        }
    }
   

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Boy")
        {
            rode = true;
            countBoy++;
        }
    }

    IEnumerator Waitt()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("GameOver");
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Out")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
