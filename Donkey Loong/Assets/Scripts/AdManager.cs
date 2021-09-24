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

    // appID ca-app-pub-7351680009694563~6700775843

    public string appID = "appID ca-app-pub-7351680009694563~6700775843";
    public string interstitialID = "ca-app-pub-3940256099942544/1033173712";
    public string bannerID = "ca-app-pub-3940256099942544/6300978111";

    public AdPosition position;

    void Start()
    {
        MobileAds.Initialize(appID);


    }

    public void BannerAD()
    {
        bannerAd = new BannerView(bannerID, AdSize.Banner, position);
        bannerText.text = "banner is okay";

        AdRequest yeniReklam = new AdRequest.Builder().Build();
        bannerText.text = "Banner request";
        bannerAd.LoadAd(yeniReklam);

        bannerAd.Show();

        bannerText.text = "banner showed";
    }

    public void GecisAD()

    {
        fullScreenText.text = " tam ekran";
        interstitialAd = new InterstitialAd(interstitialID);
        AdRequest yeniReklam = new AdRequest.Builder().Build();

        interstitialAd.LoadAd(yeniReklam);

        fullScreenText.text = "tam ekran yüklendi";

    }

    public void GecisReklamıGoster()
    {
        if(interstitialAd.IsLoaded())
        {
            fullScreenText.text = "tam ekran acıldı";
            interstitialAd.Show();
        }
        else
        {
            fullScreenText.text = "tam ekran acılmadı";
        }
    }

    public void BannerGızle()
    {
        bannerText.text = "Gizleme";

        bannerAd.Hide();
    }
}
