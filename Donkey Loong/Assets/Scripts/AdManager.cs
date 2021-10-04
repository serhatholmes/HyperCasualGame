using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    private BannerView bannerAD;
    private InterstitialAd interstitialAD;
    //private Rewar rewardBasedVideo;

    public static AdManager instance;

    // appID = ca-app-pub-3940256099942544~3347511713

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });

        //this.rewardBasedVideo = RewardedInterstitialAd.Instance;

        //this.rewardBasedVideo.OnAdRewarded +=

        this.RequestBanner();


    }

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

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        this.bannerAD = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
        
        this.bannerAD.LoadAd(this.CreateAdRequest());

    }

    public void RequestInterstital()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";

        if (this.interstitialAD != null)
            this.interstitialAD.Destroy();

        this.interstitialAD = new InterstitialAd(adUnitId);

        this.interstitialAD.LoadAd(this.CreateAdRequest());
    }

    public void ShowInterstital()
    {
        if(this.interstitialAD.IsLoaded())
        {
            interstitialAD.Show();
        }
        else
        {
            Debug.Log("inter not ready");
        }
    }

    public void RequestRewardBasedVideo()
    {
        string adUnitId = "ca-app-pub-3940256099942544/5354046379";

        //this.rewardBasedVideo.LoadAd(this.CreateAdRequest(), adUnitId);
    }

    public void ShowRewardBasedVideo()
    {
        /*if(this.rewardBasedVideo.IsLoaded())
        {
            this.rewardBasedVideo.Show();
        }
        else
        {

        } */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
