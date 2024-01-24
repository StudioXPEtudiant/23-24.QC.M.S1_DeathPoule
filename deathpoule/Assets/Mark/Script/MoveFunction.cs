using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class MoveFunction : MonoBehaviour
{
    
    [SerializeField] private float speed = 5;
    [SerializeField] private float deceleration = 5;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float vMax = 10;
    private Rigidbody2D _rigidbody;

    public bool isRight;
    [NotNull] private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private int _jumpCount = 1;
    public int jumpCount;
    public float isGrounded;
    
        
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        ResetJumpCount();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        if(Input.GetAxis("Vertical") > 0 && jumpCount > 0)
        {
            
            Jump();
            jumpCount -= 1;
            
        }

        SpriteOrientation(isRight);
        
        if(_rigidbody.velocityY == 0)
            ResetJumpCount();
    }
    
    public void Move()
    {
        
        if(Input.GetAxis("Horizontal") > 0)
        {
            _rigidbody.velocity = Vector2.right * speed + _rigidbody.velocity * Vector2.up;
            isRight = true;

        }
        
        if(Input.GetAxis("Horizontal") < 0)
        {
            _rigidbody.velocity = Vector2.left * speed + _rigidbody.velocity * Vector2.up;
            isRight = false;
            
        }
        
        if(Input.GetAxis("Horizontal") == 0)
        {
            if(isRight)
            {
                _rigidbody.velocity = _rigidbody.velocity * Vector2.up - Vector2.right * deceleration;

                if (_rigidbody.velocityX < 0)
                    _rigidbody.velocityX = 0;
            }
            else if(!isRight)
            {
                _rigidbody.velocity = _rigidbody.velocity * Vector2.up - Vector2.left * deceleration;

                if (_rigidbody.velocityX > 0)
                    _rigidbody.velocityX = 0;
            }
        }
        
        if (Mathf.Abs(_rigidbody.velocityX) > vMax)
        {
            if (isRight)
                _rigidbody.velocityX = vMax;
            else
                _rigidbody.velocityX = -vMax;
        }
        
        if (Mathf.Abs(_rigidbody.velocityY) > vMax)
        {
            if (_rigidbody.velocityY > 0)
                _rigidbody.velocityY = vMax;
            else
                _rigidbody.velocityY = -vMax;
        }
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * jumpForce);
    }

    public void ResetJumpCount()
    {
        jumpCount = _jumpCount;
    }

    void SpriteOrientation(bool rigth)
    {
        if (rigth)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;
    }
}
