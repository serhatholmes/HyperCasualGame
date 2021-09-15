using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterChanging : MonoBehaviour
{

    [SerializeField] public TMP_Text lockedText1;
    [SerializeField] private GameObject[] characterList;
    [SerializeField] private GameObject buyButton;
    [SerializeField] private GameObject chooseButton;
    public List<int> unlockedList;
    private int index=0; 

    [SerializeField] CoinPoints pointDec;
    public int decrease = 100;
    GameObject coinn;
    string coin;
    public TMP_Text coinText;
    
    static GameObject unlockedImage;
    
    void Start()
    {
       /* if (PlayerPrefs skin1 açıksa)
            unlockedList.Add(0);
        if (ikinci açıksa)
                elşe  */
        unlockedImage = GameObject.FindGameObjectWithTag("unlocked");

        //lockedText1 = gameObject.GetComponent<TextMeshProUGUI>();
        
        //Text text = coinText.GetComponent<Text>();
        //text.text = coin;

        index = PlayerPrefs.GetInt("CharacterSelected");
            
            characterList = new GameObject[transform.childCount];

        
            //Fill the array with our models
            for(int i=0; i < transform.childCount; i++)
            {
                characterList[i] = transform.GetChild(i).gameObject;

            }
            //we toggle off their renderer
            foreach(GameObject go in characterList)
            {
                go.SetActive(false);
            }

            //we toggle on the selected character
            if (characterList[index])
                characterList[index].SetActive(true);


        if (unlockedList.Contains(index))
        {
            unlockedImage.SetActive(false);
            buyButton.SetActive(false);
            chooseButton.SetActive(true);

        }
        else
        {
            unlockedImage.SetActive(true);
            buyButton.SetActive(true);
            chooseButton.SetActive(false);
        }



    }
    
    void Update()
    {
        
    }

    public void ToggleLeft()
    {
        // toggle off the current model
        characterList[index].SetActive(false);

        index--;
        if (index < 0)
            index = characterList.Length - 1;

        // toggle on the new model
        characterList[index].SetActive(true);

        if (unlockedList.Contains(index))
        {
            unlockedImage.SetActive(false);
            buyButton.SetActive(false);
            chooseButton.SetActive(true);
        }
        else
        {
            unlockedImage.SetActive(true);
            buyButton.SetActive(true);
            chooseButton.SetActive(false);
        }
    }

    public void ToggleRight()
    {
        // toggle off the current model
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
            index = 0;

        // toggle on the new model
        characterList[index].SetActive(true);

        if (unlockedList.Contains(index))
        {
            unlockedImage.SetActive(false);
            buyButton.SetActive(false);
            chooseButton.SetActive(true);
        }
        else
        {
            unlockedImage.SetActive(true);
            buyButton.SetActive(true);
            chooseButton.SetActive(false);
        }


    }

    public void ConfirmButton()
    {
        //lockedText1.text = "UNLOCKED";
        //pointDec.boughtSkin();
        Debug.Log("Selected");
        PlayerPrefs.SetInt("CharacterSelected", index);
        //unlockedImage.SetActive(false);


    }

    public void BuyButton()
    {
        if (pointDec.checkWallet())
        {
            pointDec.buySkinButton();
            if (!unlockedList.Contains(index))
            {
                unlockedList.Add(index);
                unlockedImage.SetActive(false);
               // if (index 1 se) playerpref 1. skin = true
                buyButton.SetActive(false);
            }
        }
        

        PrintUnlockedList();
    }

    void PrintUnlockedList()
    {
        Debug.Log("UNLOCKED LIST");
        foreach(var unlocked in unlockedList)
        {
            Debug.Log(unlocked);
        }
        Debug.Log("-------------------------");
    }




}
