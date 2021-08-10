using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyUI.Toast;

public class SceneMang : MonoBehaviour
{

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
        SceneManager.LoadScene("GameOver");
    }

    public void Win()
    {
        AudioManager.instance.Play("clap");
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

    // add rewarded and other adds

    public void showAds()
    {
        Debug.Log("ADS");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
