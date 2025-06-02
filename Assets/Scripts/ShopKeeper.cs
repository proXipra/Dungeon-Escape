using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _shopPanel.SetActive(false);
        }
    }
}
