using UnityEngine;

public class AdsManager : MonoBehaviour
{
    

    private static AdsManager _instance;
    public static AdsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AdsManager instance is NULL");
            }
            return _instance;
        }
    }

    public RewardedAds rewardedAds;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        rewardedAds.LoadRewardedAd();
    }
}
