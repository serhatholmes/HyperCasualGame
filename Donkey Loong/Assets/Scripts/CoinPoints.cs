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

        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayerPrefs.SetInt("Coins", 5000);
            coin = PlayerPrefs.GetInt("Coins");
        }
    }


    public void coinIncrease()
    {
        Debug.Log("coinarttı");
        coin = PlayerPrefs.GetInt("Coins") + 375;

        PlayerPrefs.SetInt("Coins", coin);
        //coinParticle.Play();

        currencyUI.text = " " + coin.ToString();

       // Destroy(this.gameObject);

    }  

    public void displayGoldScore()
    {
        currencyUI.text = PlayerPrefs.GetInt("Coins").ToString();
    }
    

    public void buySkinButton()
    {
        coin = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 10000);
        displayGoldScore();

        
    }

    public bool checkWallet()
    {
        coin = PlayerPrefs.GetInt("Coins");
        if (coin >= 1000)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator coinDeath()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }


}
