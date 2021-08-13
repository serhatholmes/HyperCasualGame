using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OddEvenn : MonoBehaviour
{
    CoinTurn coinPoint;

    public string randomNumb;

    public int theNumber;

    public Button oddbutton;

    public Button evenButton;

    public GameObject theNumb;

    // Start is called before the first frame update
    void Start()
    {
        //theNumb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomGenerate ()
    {
        theNumber = Random.Range(1, 10);

        theNumber = theNumber % 2;

        

        theNumb.GetComponent<Text>().text = "" + theNumber;

        //randomNumb = theNumber.ToString();

        StartCoroutine("Waitttt");


    }


    IEnumerator Waitttt()
    {
        Debug.Log("basladi");
        yield return new WaitForSecondsRealtime(2);
        //theNumb.SetActive(true);
        theNumb.GetComponent<Text>().text = "" + theNumber;
        yield return new WaitForSecondsRealtime(2);
        OddButton();
    }

    public void OddButton()
    {
        if(theNumber % 2 == 1)
        {
            StartCoroutine("Waitttt");
            SceneManager.LoadScene("WinScene");
        }

        else
        {
            StartCoroutine("Waitttt");
            SceneManager.LoadScene("GameOver");
        }
    }

    public void EvenButton()
    {
        if(theNumber % 2 == 0)
        {
            StartCoroutine("Waitttt");
            SceneManager.LoadScene("WinScene");
        }

        else
        {
            StartCoroutine("Waitttt");
            SceneManager.LoadScene("GameOver");
        }
    }
}
