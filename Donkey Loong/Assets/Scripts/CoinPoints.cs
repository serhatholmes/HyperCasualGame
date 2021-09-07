using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinPoints : MonoBehaviour
{

    public TextMeshProUGUI coinDisplayText;

    public int currentCoins = 0;

    public int decrs = 125;

    // Start is called before the first frame update
    void Start()
    {
        coinDisplayText = GetComponent<TextMeshProUGUI>();

        //coin sayısını saklamak için
        if (PlayerPrefs.HasKey("CoinPoints"))
        {
            currentCoins = PlayerPrefs.GetInt("CoinPoints");
        }

        coinDisplayText.text = " " + currentCoins.ToString();
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
        /* else if(other.tag != "Donkey")
        {
            return;
        } */


        //add the score later
        else if (other.tag == "Boy")
        {
            
            
            Debug.Log("coin");
            currentCoins += decrs;
            PlayerPrefs.SetInt("CoinPoints", currentCoins);
            
            coinDisplayText.text = " " + currentCoins;
            Destroy(gameObject);


        }
        /*
        else if(other.tag == "Donkey")
        {
            Debug.Log("coin");
            currentCoins += decrs;
            PlayerPrefs.SetInt("CoinPoints", currentCoins);

            coinDisplayText.text = " " + currentCoins;
            //Destroy(gameObject);
        }
        */
    }

   /* public void boughtSkin()
    {
        currentCoins = currentCoins - decrs;
    } */
}
