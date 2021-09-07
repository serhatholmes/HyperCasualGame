using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class OddEvenn : MonoBehaviour
{
    CoinTurn coinPoint;

    public string randomNumb;

    public int theNumber;

    public Button oddbutton;

    public Button evenButton;

    public TextMeshProUGUI theNumb;

    public GameObject Panel;

    public GameObject panelGamePlay;

    public bool temp = true;

    // Start is called before the first frame update
    void Start()
    {
        theNumb = GetComponent<TextMeshProUGUI>();
        //theNumb.SetActive(false);

        DOTween.Init();
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(temp== false)
        {
            WinStiuation();
        }
    }

    public void RandomGenerate ()
    {
        

        //randomNumb = theNumber.ToString();

        StartCoroutine("Waitttt");


    }

    public void OpenPanel()
    {
        Panel.SetActive(true);
        panelGamePlay.SetActive(false);
        
    }



   public void WinStiuation()
    {



        //PlayerPrefs.SetInt("CoinPoints", PlayerPrefs.GetInt("CoinPoints") + 200);
        OpenPanel();

    }



    IEnumerator Waitttt()
    {

        
        theNumber = Random.Range(1, 10);

        //theNumber = theNumber % 2;



        theNumb.text = "Skor: " + theNumb.ToString();


        Debug.Log("basladi");

        
       
        yield return new WaitForSeconds(5);
    }

    IEnumerator forWin()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("WinScene");
    }

    IEnumerator forLoose()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
    }


    public void OddButton()
    {
        StartCoroutine(Waitttt());

        if (theNumber % 2 == 1)
        {

            StartCoroutine(forWin());

        }

        else
        {
            StartCoroutine(forLoose());

        }
        
    }

    public void EvenButton()
    {
        StartCoroutine(Waitttt());

        if (theNumber % 2 == 0)
        {
            
            StartCoroutine(forWin());
        }

        else
        {
            StartCoroutine(forLoose());

        }
    }

   
}
