using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class Admob_Manager_v2 : MonoBehaviour
{
    public static Admob_Manager_v2 instance;

    public int rewardedIndex = 0;

    private bool interstialReady = false;
    private bool rewardedReady = false;
    private bool rewardedWatched = false;
    public bool rewardedReadyPublic = false;

    private void Awake()
    {
        instance = this;
    }



    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;

    void Start()
    {
        try
        {
            MobileAds.Initialize(initStatus => { });
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Admob initialize fail  " + ex.Message);
            //throw;
        }
        RequestInterstitial();
        RequestRewarded();
    }




    #region Interstial 
    public void RequestInterstitial()
    {
        System.Diagnostics.Debug.WriteLine("Inter Requested");
        if (interstialReady)
        {
            System.Diagnostics.Debug.WriteLine("Inter Showing");
            interstialReady = false;
            this.interstitial.Show();
        }
        else
        {



#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-7351680009694563/4398046136";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-1851788608988306/3211657204";
#else
        string adUnitId = "unexpected_platform";
#endif

            // Initialize an InterstitialAd.
            this.interstitial = new InterstitialAd(adUnitId);

            // Called when an ad request has successfully loaded.
            this.interstitial.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is shown.
            this.interstitial.OnAdOpening += HandleOnAdOpened;
            // Called when the ad is closed.
            this.interstitial.OnAdClosed += HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            //this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;



            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);


            //if (this.interstitial.IsLoaded())
            //{
            //    this.interstitial.Show();
            //}

            //Debug.Log("Inter showed");
        }
    }


    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdLoaded event received");
        if (this.interstitial.IsLoaded())
        {
            //this.interstitial.Show();
            System.Diagnostics.Debug.WriteLine("InterReady");
            interstialReady = true;
        }
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        System.Diagnostics.Debug.WriteLine("HandleFailedToReceiveAd event received with message: "
                            + args.LoadAdError.GetMessage());
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
        //interstialWatched = true;
        RequestInterstitial();
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    #endregion


    #region Rewarded
    public void InvokeRewarded()
    {
        RequestRewarded();
    }

    //Test ad code ca-app-pub-3940256099942544/5224354917
    public void RequestRewarded()
    {
        System.Diagnostics.Debug.WriteLine("Rewared Requested");
        if (rewardedReady /*&& rewardedIndex != 0*/)
        {
            System.Diagnostics.Debug.WriteLine("Rewarded Showing");
            this.rewardedAd.Show();
            rewardedReady = false;

            RequestRewarded();
        }
        else
        {

#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
       string     adUnitId = "ca-app-pub-1851788608988306/1488330234";
#else
       string     adUnitId = "unexpected_platform";
#endif


            this.rewardedAd = new RewardedAd(adUnitId);

            // Called when an ad request has successfully loaded.
            this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
            // Called when an ad request failed to load.
            //this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
            // Called when an ad is shown.
            this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
            // Called when an ad request failed to show.
            this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
            // Called when the user should be rewarded for interacting with the ad.
            this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            // Called when the ad is closed.
            this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

            this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        }

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);

    }

    private void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Rewarded failed  " + e.LoadAdError.GetMessage());

        //if (!rewardedReady)
        //{
        //    RequestRewarded(0);
        //}
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
        //Debug.Log("Rewarded Succes");

        if (this.rewardedAd.IsLoaded())
        {
            System.Diagnostics.Debug.WriteLine("Rewared Ready");
            //this.rewardedAd.Show();
            rewardedReady = true;
            rewardedReadyPublic = true;
        }
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        //if (!rewardedReady)
        //{
        //    RequestRewarded();
        //}

        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             /*+ args.Messag*/);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        //Invoke("justFunc", 0.5f);
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }


    public void HandleUserEarnedReward(object sender, Reward args)
    {
        rewardedWatched = true;

        //Make earn event here

        if (rewardedWatched)
        {
            rewardedWatched = false;
        }

        if (!rewardedReady)
        {
            RequestRewarded();
        }
    }
    #endregion

}
