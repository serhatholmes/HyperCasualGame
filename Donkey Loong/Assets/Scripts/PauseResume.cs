using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    public GameObject panelPause;

    public GameObject panelGamePlay;

    public bool isTime = false;
    // Start is called before the first frame update
    void Start()
    {
        panelPause.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (isTime == true)
        {
            Time.timeScale = 0f;
        }

        else if (isTime == false)

        {
            Time.timeScale = 1f;
        }
    }

    public void pauseButton()
    {

        panelPause.SetActive(true);
        panelGamePlay.SetActive(false);
        AudioListener.volume = 0.2f;
        isTime = true;
        

    }

    public void resumeButton()
    {
        isTime = false;
        panelPause.SetActive(false);
        panelGamePlay.SetActive(true);
        AudioListener.volume = 1f;
        Time.timeScale = 1f;

    }
}
