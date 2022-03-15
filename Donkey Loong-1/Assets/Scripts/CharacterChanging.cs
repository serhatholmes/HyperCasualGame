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
    [SerializeField] private GameObject skinPrice;
    public List<int> unlockedList;
    private int index=0; 

    [SerializeField] CoinPoints pointDec;
    public int decrease = 100;
    GameObject coinn;

    string unlockedListString;

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
        if (PlayerPrefs.GetString("unlockedList") == null)
        {
            PlayerPrefs.SetString("unlockedList", "0");
        }
        unlockedListString = PlayerPrefs.GetString("unlockedList");
        foreach (var letter in unlockedListString)
        {
            if (!unlockedList.Contains(letter - '0'))
            {
                unlockedList.Add(letter - '0');
            }
        }
        foreach (var item in unlockedList)
        {
            Debug.Log(item);
        }
        

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
            skinPrice.SetActive(false);

            chooseButton.SetActive(true);

        }
        else
        {
            unlockedImage.SetActive(true);
            buyButton.SetActive(true);
            skinPrice.SetActive(true);

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
            skinPrice.SetActive(false);
            chooseButton.SetActive(true);
        }
        else
        {
            unlockedImage.SetActive(true);
            buyButton.SetActive(true);
            skinPrice.SetActive(true);
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
            skinPrice.SetActive(false);
            chooseButton.SetActive(true);
        }
        else
        {
            unlockedImage.SetActive(true);
            buyButton.SetActive(true);
            skinPrice.SetActive(true);
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
        SceneManager.LoadScene("Game");

    }

    public void BuyButton()
    {
        if (pointDec.checkWallet())
        {
            pointDec.buySkinButton();
            if (!unlockedList.Contains(index))
            {
                unlockedList.Add(index);
                unlockedListString = "";
                foreach (var item in unlockedList)
                {
                    unlockedListString += item.ToString();
                }
                PlayerPrefs.SetString("unlockedList", unlockedListString);
                unlockedImage.SetActive(false);
               // if (index 1 se) playerpref 1. skin = true
                buyButton.SetActive(false);
                chooseButton.SetActive(true);
                skinPrice.SetActive(false);

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
