using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public InitiliseAds initiliseAds;
    public BannerAds bannerAds;
    public InterstetialAds interstetialAds;
    public RewardedAds rewardedAds;

    public static AdsManager instance { get; private set; }

    private void Awake()
    {
        if(instance!=null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        Destroy(gameObject);

        bannerAds.LoadBanner();
        interstetialAds.LoadInterstetialAd();
        rewardedAds.LoadRewardedAd();
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
