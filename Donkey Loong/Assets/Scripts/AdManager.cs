using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IronSourceJSON;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    public Text Rewardedstatus;

    // Start is called before the first frame update
    void Start()
    {
        IronSource.Agent.init("116d4c65d", IronSourceAdUnits.REWARDED_VIDEO, IronSourceAdUnits.INTERSTITIAL, IronSourceAdUnits.OFFERWALL, IronSourceAdUnits.BANNER);

        Invoke("InitBanner", 1f);
        Invoke("FullScreenAd", 2f);
        
    }

    void Update()
    {
        Rewardedstatus.text = IronSource.Agent.isRewardedVideoAvailable().ToString();
    }

    //banner

    public void InitBanner()
    {
        IronSource.Agent.loadBanner(IronSourceBannerSize.SMART, IronSourceBannerPosition.TOP);
        

    }

    public void FullScreenAd()
    {
        IronSource.Agent.loadInterstitial();
    }

    public void ShowFullScreenAd()
    {
        IronSource.Agent.showInterstitial();
    }

    public void RewardedAdShow()
    {
        IronSource.Agent.showRewardedVideo();
    }
}
