using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour , IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string _androidAdUnitId;
    [SerializeField] private string _iosAdUnitId;

    private string _adUnitId; 

    private void Awake()
    {
        #if UNITY_IOS
            _adUnitId = _iosAdUnitId;
        #elif UNITY_ANDROID
            _adUnitId = _androidAdUnitId;
        #endif
    }

    public void LoadRewardedAd()
    {
        Advertisement.Load(_adUnitId, this);    
    }

    public void ShowRewardedAd()
    {
        Advertisement.Show(_adUnitId, this);
        LoadRewardedAd();
    }

    #region LoadCallbacks

    public void OnUnityAdsAdLoaded(string placementId){ }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message){ }

    #endregion

    #region ShowCallbacks

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }

    public void OnUnityAdsShowStart(string placementId) { }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) 
    {
        if (placementId == _adUnitId && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Ad fully watched!");
        }
    }

    #endregion
}
