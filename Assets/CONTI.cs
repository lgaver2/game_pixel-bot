using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class CONTI : MonoBehaviour
{
    private string Message;
    public GameObject robot;
    private RewardedAd rewardedAd;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("new_game", 1);
#if UNITY_ANDROID
        string appId = "ca-app-pub-7990116686246806~8990491327";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544~1458002511";
#else
        string appId = "unexpected_platform";
#endif
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
        RequestRewardAd();

    }

    private void Update()
    {

    }


    public void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }


    void RequestRewardAd()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-7990116686246806/4425147081";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif
        this.rewardedAd = new RewardedAd(adUnitId);

        // Load成功時に実行する関数の登録
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Load失敗時に実行する関数の登録
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // 表示時に実行する関数の登録
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // 表示失敗時に実行する関数の登録
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // 報酬受け取り時に実行する関数の登録
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // 広告を閉じる時に実行する関数の登録
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }







    public void CreateAndLoadRewardedAd()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-7990116686246806/4425147081";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            string adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }


    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);

    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        CreateAndLoadRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
        continues();
    }
  
    public void continues()
    {
        robot.GetComponent<character_move>().restart();
    }
    
    public void quit()
    {
        SceneManager.LoadScene("title_scene");
        PlayerPrefs.SetInt("new_game", 0);
    }
   
}

