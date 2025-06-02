using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float _moveSpeed;
    [SerializeField] float moveDirection;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyInSeconds());
    }

    private void Update()
    {
        _rb.linearVelocity = new Vector2(_moveSpeed * moveDirection, _rb.linearVelocityY);
    }


    public void AssignAcidDirection(bool flipSpriteX)
    {
        if (flipSpriteX == true)
        {
            moveDirection = Vector2.left.x;
        }
        else
        {
            moveDirection = -Vector2.left.x;
        }

    }
    
    private void OnTriggerEnter2D (Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();
        if (hit != null)
        {
            hit.Damage();
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyInSeconds()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
