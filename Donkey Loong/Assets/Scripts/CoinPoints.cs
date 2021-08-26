using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinPoints : MonoBehaviour
{

    public TextMeshProUGUI coinDisplayText;

    public int currentCoins = 0;

    public int decrs = 100;

    // Start is called before the first frame update
    void Start()
    {
        //coin sayısını saklamak için
        if (PlayerPrefs.HasKey("CoinSystem"))
        {
            currentCoins = PlayerPrefs.GetInt("CoinSystem");
        }

        coinDisplayText.text = " " + currentCoins;
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
            
            Destroy(gameObject);
            Debug.Log("coin");
            currentCoins += 100;
            PlayerPrefs.SetInt("CoinSystem", currentCoins);
            coinDisplayText.SetText(currentCoins.ToString());
            coinDisplayText.text = " " + currentCoins;


        }
    }

   /* public void boughtSkin()
    {
        currentCoins = currentCoins - decrs;
    } */
}
