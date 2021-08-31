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
    

    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
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
        PlayerPrefs.SetInt("CoinPoints", PlayerPrefs.GetInt("CoinPoints") + 200);
        SceneManager.LoadScene("WinScene");
    }

    public void Setting()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Dont()
    {
        return;
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

    public void showAds()
    {
        Debug.Log("ADS");
    }

    // Start is called before the first frame update
    void Start()
    {
        //currentp = winPoints.currentCoins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
