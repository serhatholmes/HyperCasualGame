using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyUI.Toast;
using UnityEngine.UI;

public class SceneMang : MonoBehaviour
{
    public int currentp;

    bool isMute = false;


    CoinPoints winPoints;

    //public GameObject panelPause;

    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
        
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void GameOver()
    {
        AudioManager.instance.Play("Nooo");
        SceneManager.LoadScene("GameOver");
    }

    

    public void Win()
    {
        
        SceneManager.LoadScene("WinScene");
    }

    public void Setting()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LooseScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void printMessage(string message)
    {
        Toast.Show(message, 0.7f);
    }

    public void MusicMute()
    {
        if(isMute==false)
        {
            Debug.Log("Music is ON");
            AudioListener.volume = 0;
            isMute = true;
        }
        else
        {
            Debug.Log("Music is OFF");
            AudioListener.volume = 1;
            isMute = false;
        }
    }

   

    // add rewarded and other adds



    // Start is called before the first frame update
    void Awake()
    {
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
