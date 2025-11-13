using System;
using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine; // name space

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D _rb;
    private Animator _animator;
    private CapsuleCollider2D _collider;
    
    public Transform groundCheck;

    public LayerMask groundLayer;
    
    private float _moveX;

    public bool canMove = true;
    public bool isGrounded;
    
    public AudioClip jumpSound;

    public AudioClip landingSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update() // function
    {
        if (canMove)
        {
            HandleMovement();
            HandleAnimations();
            FlipSprite();
        }
    }

    private void HandleMovement()
    {
        var g = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); // raycast
        if (!isGrounded && g)
        {
            // landing frame
            AudioManager.instance.PlaySfx(landingSound);
        }
        isGrounded = g;
        _moveX = Input.GetAxis("Horizontal"); // if A(left arrow), -1. if D (right arrow), +1. if nothing, 0.
        _rb.linearVelocity = new Vector2(_moveX * speed, _rb.linearVelocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            AudioManager.instance.PlaySfx(jumpSound);
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
        }
    }

    private void HandleAnimations()
    {
        _animator.SetBool("isRunning", _rb.linearVelocity.x != 0); // if player's moving, true.
        _animator.SetBool("isRising", _rb.linearVelocity.y > 0);
        _animator.SetBool("isFalling", _rb.linearVelocity.y < 0);
    }

    private void FlipSprite()
    {
        if (_moveX < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else if (_moveX > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }

    // Trigger function
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            UIManager.instance.Win();
            canMove = false;
            _animator.SetBool("isRunning", false);
        }
    }

}
