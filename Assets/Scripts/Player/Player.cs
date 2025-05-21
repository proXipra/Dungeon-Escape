using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private BoxCollider2D _bc;
    private PlayerAnimation _anim;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _arcSprite;

    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _jumpForce = 250f;
    private bool _delayJumping;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();  
        _bc = GetComponent<BoxCollider2D>();   
        _anim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _arcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Mouse0) && IsGrounded())
        {
            //Debug.Log("Attack!");
            _anim.Attack();
        }
    }

    void Movement()
    {

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * _jumpForce);
            StartCoroutine(DelayJumping());
            _delayJumping = true;   
            _anim.UpdateBool("Jumping", true);
        }
        // 
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _rb.linearVelocity = new Vector2(horizontalInput * _moveSpeed, _rb.linearVelocityY);
        //

        Flip(horizontalInput);
        _anim.Move(horizontalInput);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(_bc.bounds.center.x, _bc.bounds.min.y), Vector3.down, 0.2f, 1 << 7);

        if (hit && _delayJumping == false)
        {
            _anim.UpdateBool("Jumping", false);
            return true;
        }
        return false;
    }

    void Flip(float horizontalInput)
    {
        if (horizontalInput == 0) { return; }

        bool shouldFlip = horizontalInput < 0;
        if (_playerSprite.flipX != shouldFlip)
        {
            _playerSprite.flipX = shouldFlip;
            _arcSprite.flipY = shouldFlip;
        }
    }


    IEnumerator DelayJumping()
    {
        yield return new WaitForSeconds(0.3f);
        _delayJumping = false;
    }
}
