using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    { 
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is NULL");
            }
            return _instance;
        }
    }

    [SerializeField] private TextMeshProUGUI _playerGemCountText;


    private void Awake()
    {
        _instance = this;
    }


    public void OpenShop(int gemCount)
    {
        _playerGemCountText.text = "" + gemCount.ToString() + "G";
    }
}
