using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    [SerializeField] public Sprite newButtonImage;
    public Button button;
    public Button buttonFX;

    public Sprite originalButtonImage;
    private bool isOriginal = true;
    

    

    

    // Start is called before the first frame update
    void Start()
    {

        button.image.sprite = originalButtonImage;
        buttonFX.image.sprite = originalButtonImage;
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
            buttonFX.image.sprite = newButtonImage;
            isOriginal = false;

        }

        else
        {

            button.image.sprite = originalButtonImage;
            buttonFX.image.sprite = originalButtonImage;
            isOriginal = true;

        }
    }
}
