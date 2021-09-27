using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    public Text bannerText, fullScreenText;

    private BannerView bannerAd;
    private InterstitialAd interstitialAd;
    private RewardedAd rewardıdAd;

    public static AdManager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // appID ca-app-pub-7351680009694563~6700775843

    public string appID = "ca-app-pub-3940256099942544";
    public string interstitialID = "ca-app-pub-3940256099942544/1033173712";
    public string bannerID = "ca-app-pub-3940256099942544/6300978111";
    public string rewardID = "ca-app-pub-3940256099942544/5224354917";

    public AdPosition position;

    void Start()
    {
        MobileAds.Initialize(appID =>{ });

        BannerAD();

    }

    public void BannerAD()
    {
        bannerAd = new BannerView(bannerID, AdSize.Banner, position);
        

        AdRequest yeniReklam = new AdRequest.Builder().Build();
        //bannerText.text = "Banner request";
        bannerAd.LoadAd(yeniReklam);

        //AdSize adSize = new AdSize(720, 50);

        bannerAd.Show();

        //bannerText.text = "banner showed";
    }

    public void GecisAD()

    {
        //fullScreenText.text = " tam ekran";
        interstitialAd = new InterstitialAd(interstitialID);
        AdRequest yeniReklam = new AdRequest.Builder().Build();

        interstitialAd.LoadAd(yeniReklam);

        

        //fullScreenText.text = "tam ekran yüklendi";
        GecisReklamıGoster();
    }

    public void GecisReklamıGoster()
    {
        if(interstitialAd.IsLoaded())
        {
            //fullScreenText.text = "tam ekran acıldı";
            interstitialAd.Show();
        }
        else
        {
            //fullScreenText.text = "tam ekran acılmadı";
        }
    }

    public void BannerGızle()
    {
        //bannerText.text = "Gizleme";

        bannerAd.Hide();
    }

    public void rewardAD()
    {
        rewardıdAd = new RewardedAd(rewardID);
        AdRequest yeniReklam = new AdRequest.Builder().Build();

        rewardıdAd.LoadAd(yeniReklam);

        rewardADShow();

    }

    public void rewardADShow()
    {
        if(rewardıdAd.IsLoaded())
        {
            rewardıdAd.Show();
        }
        else
        {
             
        }
    }

    public void adDestroy()
    {
        // remove ads için ad.Destroy();
    }
}
