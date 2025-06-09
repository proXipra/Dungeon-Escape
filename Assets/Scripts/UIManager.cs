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
    [SerializeField] private GameObject _selection;
    public int selectedItem { get; set; }



    private void Awake()
    {
        _instance = this;
    }


    public void OpenShop(int gemCount)
    {
        _playerGemCountText.text = "" + gemCount.ToString() + "G";
    }

    public void PlaceSelection(int itemID)
    {
        if (_selection.activeInHierarchy == false)
        {
            _selection.SetActive(true);
        }
        RectTransform selectionRect = _selection.GetComponent<RectTransform>();
        selectionRect.anchoredPosition = new Vector2(selectionRect.anchoredPosition.x, -105 * itemID - 50);
    }
}
