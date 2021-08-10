using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinTurn : MonoBehaviour
{
    public float turnSpeed = 90f;

    GoldScore goldPlus;

    public TextMeshProUGUI coinDisplayText;

    public int currentCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        //coin sayısını saklamak için
        if(PlayerPrefs.HasKey("CoinSystem"))
        {
            currentCoins = PlayerPrefs.GetInt("CoinSystem");
        }

        coinDisplayText.text = " " + currentCoins;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed* Time.deltaTime);

        
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
            // destroy the coin
            Destroy(gameObject);
            Debug.Log("coin");
            currentCoins += 75;
            PlayerPrefs.SetInt("CoinSystem", currentCoins);
            coinDisplayText.SetText(currentCoins.ToString());
            coinDisplayText.text = " " + currentCoins;


        }
    }
}
