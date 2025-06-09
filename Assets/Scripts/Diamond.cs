using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.diamond++;
            Debug.Log("Player Diamond Count: "+ player.diamond);
            Destroy(this.gameObject);
        }
    }
}
