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
                UIManager.Instance.OpenShop(_player.diamond);
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
            if (_player.diamond >= _selectedItemCost)
            {
                _player.diamond -= _selectedItemCost;
                Debug.Log("Remaining Gems: "+ _player.diamond);
            }
            else
            {
                Debug.Log("Sufficient balance");
            }
        }
        
    }
}



