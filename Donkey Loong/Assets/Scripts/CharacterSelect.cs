using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public List<Player> characters = new List<Player>();

    private GameObject selectedGameobject;
    private int _index;


    void Awake()
    {
        _index = PlayerPrefs.GetInt("CharacterSelected");

        foreach (var character in characters)
            if (character.characterIndex == _index)
            {
                selectedGameobject = character.gameObject;
                selectedGameobject.SetActive(true);
            }
                

    }

    public GameObject GetSelectedCharacter()
    {
        return selectedGameobject;
    }
}
