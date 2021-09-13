using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinPoints : MonoBehaviour
{
    public int coin = 0;

    [SerializeField] TMP_Text currencyUI;

    public int increment = 125;

    public bool destroy1 = false;

    void Awake()
    {
        currencyUI = GameObject.FindGameObjectWithTag("GoldScore").GetComponent<TMP_Text>();
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            coin = PlayerPrefs.GetInt("Coins");
            currencyUI.text = " " + coin.ToString();
        }

        //currencyUI =

        
        //coinParticle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerPrefs.Save();

        if (destroy1 == true)
        {
            Destroy(gameObject);
        }
    }


    public void coinIncrease()
    {
        Debug.Log("coinarttı");
        coin = PlayerPrefs.GetInt("Coins") + 125;

        PlayerPrefs.SetInt("Coins", coin);
        //coinParticle.Play();

        currencyUI.text = " " + coin.ToString();

       // Destroy(this.gameObject);

    }  

    
    

    public void buySkinButton()
    {
        coin -= 1000;
    }

    IEnumerator coinDeath()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }


}
