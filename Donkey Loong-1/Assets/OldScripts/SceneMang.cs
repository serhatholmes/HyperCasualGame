using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyUI.Toast;
using UnityEngine.UI;
using TMPro;

public class SceneMang : MonoBehaviour
{
    public int currentp;

    bool isMute = false;
    bool isMusicMute = false;

    CoinPoints coinAd;

    [SerializeField] TMP_Text goldText;

    CoinPoints winPoints;

    AdManager reklamManager;

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

        Debug.LogWarning("PUAN VER");
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 275);
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

    public void MuteMusicOnly()
    {
        isMusicMute = !isMusicMute;
        if (isMusicMute)
        {
            var audioManager = GameObject.FindGameObjectWithTag("AudioManager");
            var a = audioManager.GetComponents<AudioSource>();
            foreach (var s in a)
            {
                if (s.clip.name == "Theme")
                {
                    s.mute = true;
                }
            }
        }
        else
        {
            var audioManager = GameObject.FindGameObjectWithTag("AudioManager");
            var a = audioManager.GetComponents<AudioSource>();
            foreach (var s in a)
            {
                if (s.clip.name == "Theme")
                {
                    s.mute = false;
                }
            }
        }
    }

    public void MusicMute()
    {
        if (isMute == false)
        {
            Debug.Log("Music is OFF");
            AudioListener.volume = 0;
            isMute = true;
        }
        else
        {
            Debug.Log("Music is ON");
            AudioListener.volume = 1;
            isMute = false;
        }
    }

    IEnumerator playInterstitialAds()
    {

        yield return new WaitForSeconds(5);
    }

    public void removeADS()
    {

    }


    // add rewarded and other adds

    void Start()
    {
        //AdManager.instance.GecisAD();
    }


    // Start is called before the first frame update
    void Awake()
    {


        showCoin();

        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }

    public void showCoin()
    {
        goldText.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    public void buyNewSkin()
    {
        //winPoints.buySkinButton();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
