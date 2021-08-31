using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinPoints1 : MonoBehaviour
{

    public Text coinDisplayText;

    public int currentCoins1;

    public int decrs = 100;

    CoinPoints CP;

    // Start is called before the first frame update
    void Start()
    {
        currentCoins1 = CP.currentCoins;

        //coin sayısını saklamak için
        if (PlayerPrefs.HasKey("CoinPoints1"))
        {
            currentCoins1 = PlayerPrefs.GetInt("CoinPoints1");
        }

        coinDisplayText.text = " " + currentCoins1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //check that object
        if (other.tag != "Boy")
        {
            return;
        }


        //add the score later
        else if (other.tag == "Boy")
        {
            
            
            Debug.Log("coin");
            currentCoins1 += decrs;
            PlayerPrefs.SetInt("CoinPoints1", currentCoins1);
            
            coinDisplayText.text = " " + currentCoins1;
            Destroy(gameObject);


        }
    }

   /* public void boughtSkin()
    {
        currentCoins = currentCoins - decrs;
    } */
}
