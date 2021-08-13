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
        theNumb.SetActive(false);
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
        Debug.Log("girdi");
        yield return new WaitForSecondsRealtime(1);
        theNumb.SetActive(true);
    }

    public void OddButton()
    {

    }

    public void EvenButton()
    {

    }
}
