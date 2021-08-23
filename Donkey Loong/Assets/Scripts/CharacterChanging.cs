using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChanging : MonoBehaviour
{
    public Text lockedText1;

    [SerializeField]
    private List<GameObject> characterList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> storeCharacterList = new List<GameObject>();
    private int index=0;

    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

            //we toggle off their renderer
            foreach(GameObject go in storeCharacterList)
                go.SetActive(false);

            //we toggle on the selected character
            if (storeCharacterList[index])
                storeCharacterList[index].SetActive(true); 
        
    }

    public void ToggleLeft()
    {
        // toggle off the current model
        storeCharacterList[index].SetActive(false);

        index--;
        if (index < 0)
            index = storeCharacterList.Count - 1;

        // toggle on the new model
        storeCharacterList[index].SetActive(true);


    }

    public void ToggleRight()
    {
        // toggle off the current model
        storeCharacterList[index].SetActive(false);

        index++;
        if (index == storeCharacterList.Count)
            index = 0;

        // toggle on the new model
        storeCharacterList[index].SetActive(true);


    }

    public void ConfirmButton()
    {
        lockedText1.text = "Unlocked";

        PlayerPrefs.SetInt("CharacterSelected", index);
    }






}
