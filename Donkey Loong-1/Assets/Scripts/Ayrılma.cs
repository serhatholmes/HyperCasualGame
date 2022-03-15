using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using EasyUI.Toast;

public class Ayrılma : MonoBehaviour
{

    

    

    public float force = 5f;

    

    public bool rode = false;

    public int howMany = 0;

    int countBoy = 0;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();

        



    }

    // Update is called once per frame
    void Update()
    {
        if (rode == true)
        {
            if (countBoy == 1)
            {
                transform.DOShakePosition(0.5f, new Vector3(1, 0, 1), 1, 15, false, true).OnComplete(()=>
                {
                    transform.DOMoveX(2, 0.2f);

                });
                
               
                

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

        else if (other.gameObject.tag == "Out")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator Waitt()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("GameOver");
    }

    
}
