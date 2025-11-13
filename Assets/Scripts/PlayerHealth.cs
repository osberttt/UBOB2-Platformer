using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private CapsuleCollider2D _collider;
    private PlayerController _playerController;

    private Transform respawnPoint;

    public CinemachineCamera cam;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<CapsuleCollider2D>();
        _playerController = GetComponent<PlayerController>();
        respawnPoint = GameObject.Find("Respawn Point").transform;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            GameManager.instance.deaths++;
            _playerController.canMove = false;
            _animator.SetBool("isFalling", true);
            _rb.linearVelocity = new Vector2(0, _playerController.jumpForce);
            _collider.enabled = false;
            cam.Follow = null;
            //gameOverPanel.SetActive(true);
            StartCoroutine(RespawnCo());

        }
        
        else if (other.CompareTag("Fall"))
        {
            GameManager.instance.deaths++;
            _playerController.canMove = false;
            _animator.SetBool("isFalling", true);
            _collider.enabled = false;
            cam.Follow = null;
            UIManager.instance.ShowGameOver();
        }
    }
    
    // Coroutines
    private IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(5f);
        transform.position = respawnPoint.position;
        _playerController.canMove = true;
        _rb.linearVelocity = new Vector2(0, 0);
        _collider.enabled = true;
        cam.Follow = transform;
    }
}
