using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OddEvenn : MonoBehaviour
{
    CoinTurn coinPoint;

    public Text randomNumb;

    public int theNumber;

    public Button oddbutton;

    public Button evenButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomGenerate ()
    {
        theNumber = Random.Range(1, 10);
    }
}
