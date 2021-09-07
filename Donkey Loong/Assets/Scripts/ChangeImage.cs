using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    [SerializeField] public Sprite newButtonImage;
    [SerializeField] public Sprite newButtonImage1;
    public Button button;
    public Button buttonFX;

    public Sprite originalButtonImage;
    private bool isOriginal = true;

    public Sprite originalButtonImage1;
    private bool isOriginal1 = true;




    // Start is called before the first frame update
    void Start()
    {

        
        buttonFX.image.sprite = originalButtonImage1;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void ChangeButtonImage()
    {

        if (isOriginal)
        {

            button.image.sprite = newButtonImage;
            
            isOriginal = false;

        }

        else
        {

            button.image.sprite = originalButtonImage;
            buttonFX.image.sprite = originalButtonImage;
            isOriginal = true;

        }
    }

    public void ChangeSecondImage()
    {
        if (isOriginal1)
        {

            
            buttonFX.image.sprite = newButtonImage1;
            isOriginal1 = false;

        }

        else
        {

            
            buttonFX.image.sprite = originalButtonImage1;
            isOriginal1= true;

        }
    }
}
