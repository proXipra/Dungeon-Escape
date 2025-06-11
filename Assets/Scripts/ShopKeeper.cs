using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    private Player _player;
    private int _currentlySelectedItem;
    private int _selectedItemCost;
    private bool _itemSelected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.GetComponent<Player>();
            if (_player != null)
            {
                UIManager.Instance.OpenShop(_player.Diamond);
            }
            _shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _itemSelected = false;
            _shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        UIManager.Instance.PlaceSelection(item);
        _currentlySelectedItem = item;
        Debug.Log("Selected Item: " + _currentlySelectedItem);
        switch (item)
        {
            case 0:
                _selectedItemCost = 200;
                break;
            case 1:
                _selectedItemCost = 400;
                break;
            case 2:
                _selectedItemCost = 100;
                break;
        }
        _itemSelected = true;

    }


    public void BuyItem()
    {
        if (_itemSelected == true)
        {
            if (_player.Diamond >= _selectedItemCost)
            {
                _player.Diamond -= _selectedItemCost;
                if (_currentlySelectedItem == 2)
                {
                    GameManager.Instance.HasCard = true;
                    Debug.Log("Card has bought!");
                }
                Debug.Log("Remaining Gems: "+ _player.Diamond);
            }
            else
            {
                Debug.Log("Sufficient balance");
            }
        }
        
    }
}



