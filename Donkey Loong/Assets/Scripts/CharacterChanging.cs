using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharacterChanging : MonoBehaviour
{
    
    public Text lockedText1;
    private GameObject[] characterList;
    private int index=0;

    CoinPoints pointDec;
    public int decrease = 100;
    GameObject coinn;
    string coin;
    public Text coinText;

    void Start()
    {
        
        
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


    }

    public void ConfirmButton()
    {
        lockedText1.text = "Unlocked";
        //pointDec.boughtSkin();
        PlayerPrefs.SetInt("CharacterSelected", index);


    }






}
