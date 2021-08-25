using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    /*[SerializeField] public Sprite newButtonImage;
    public Button button;

    public Sprite originalButtonImage;
    private bool isOriginal = true;
    */

    private bool stepOne = true;

    public Button powering;

    // Start is called before the first frame update
    void Start()
    {
        //tekst = powering.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void ChangeButtonImage()
    {
        

        if (stepOne)
        {
            GameObject.FindGameObjectWithTag("PowerButton").GetComponent<Text>().text = "JUMP!";
           

        }

        else
        {
            GameObject.FindGameObjectWithTag("PowerButton").GetComponent<Text>().text = "STOP!";
            

        }
    }
}
