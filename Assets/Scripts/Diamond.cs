using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.Diamond++;
            Debug.Log("Player Diamond Count: "+ player.Diamond);
            Destroy(this.gameObject);
        }
    }
}
