using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rb;
    private BoxCollider2D _bc;
    private PlayerAnimation _anim;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _arcSprite;

    public InputActionAsset InputActions;

    private InputAction m_moveAction;
    private InputAction m_jumpAction;
    private InputAction m_attackAction;

    private Vector2 m_moveAmt;


    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _jumpForce = 250f;
    private bool _delayJumping;
    public int Diamond { get; set; }
    public int Health { get; set; }

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_jumpAction = InputSystem.actions.FindAction("Jump");
        m_attackAction = InputSystem.actions.FindAction("Attack");
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();  
        _bc = GetComponent<BoxCollider2D>();   
        _anim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _arcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();

        Health = 4;
    }

    void Update()
    {

        if (Health < 1)
        {
            return;
        }
        Movement();

        if (m_attackAction.WasPressedThisFrame() && IsGrounded())
        {
            //Debug.Log("Attack!");
            _anim.Attack();
        }
    }

    void Movement()
    {

        if (IsGrounded() && m_jumpAction.WasPressedThisFrame())
        {
            _rb.AddForce(Vector3.up * _jumpForce);
            StartCoroutine(DelayJumping());
            _delayJumping = true;   
            _anim.UpdateBool("Jumping", true);
        }

        m_moveAmt = m_moveAction.ReadValue<Vector2>();
        float horizontalInput = m_moveAmt.x;
        _rb.linearVelocity = new Vector2(horizontalInput * _moveSpeed, _rb.linearVelocityY);
        

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

    public void AddGem()
    {
        Diamond++;
        UIManager.Instance.UpdateGemCount(Diamond);
    }

    IEnumerator DelayJumping()
    {
        yield return new WaitForSeconds(0.3f);
        _delayJumping = false;
    }


    public void Damage()
    {
        if (Health < 1)
        {
            return;
        }
        Health--;
        Debug.Log("Damage called!, Health: " + Health);
        UIManager.Instance.UpdateLives(Health);
        
        if (Health < 1)
        {
            _anim.Die();
        }
    }
}
