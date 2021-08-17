using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyUI.Toast;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countPlayer==5)
        {
            //PanelOpener();
            
            SceneManager.LoadScene("OddEven");
        }
        if(deathCount>6)
        {
            SceneManager.LoadScene("GameOver");
        }

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
            
            Debug.Log("tutundu");
            //jump.Play();

        }

        else if(other.gameObject.tag=="Floor")
        {
            StartCoroutine(shaker.Shake(.05f, .6f));

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
