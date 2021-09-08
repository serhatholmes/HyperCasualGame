using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class languagesPOPUP : MonoBehaviour
{
    public GameObject panelOptions;
    public GameObject panelLang;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backButton()
    {
        panelLang.SetActive(false);
        panelOptions.SetActive(true);
    }

    public void langButton()
    {
        panelLang.SetActive(true);
        panelOptions.SetActive(false);
    }
}
