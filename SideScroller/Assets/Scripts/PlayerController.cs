﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Animator PlayerAnimator;
    public Rigidbody2D Player;
    public float MoveSpeed;
    public float JumpForce;
    
    private bool _onGround = true;
    private bool _jumped = false;
    private bool _facingRight = true;
    private float _AttackingMultiplier = .3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (_onGround)
            {
                _onGround = false;
                Player.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                PlayerAnimator.SetTrigger("Jump");
            } else if (!_jumped)
            {
                _jumped = true;
                Player.velocity = new Vector2(Player.velocity.x, 0);
                Player.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                PlayerAnimator.SetTrigger("Jump");
            }
        }

        if (!_onGround || _jumped)
            PlayerAnimator.SetFloat("JumpVelocity", Player.velocity.y);

        var hSpeed = Input.GetAxis("Horizontal") * MoveSpeed;
        if (PlayerAnimator.GetBool("IsAttacking"))
        {
            hSpeed *= _AttackingMultiplier;
        } 
        if (hSpeed > 0)
            _facingRight = true;
        else if (hSpeed < 0)
            _facingRight = false;
        var calcHSpeed = hSpeed * Time.deltaTime;
        Player.transform.Translate(new Vector2(calcHSpeed, 0));

        SpriteRenderer.flipX = !_facingRight;
        PlayerAnimator.SetFloat("MoveSpeed", Math.Abs(hSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Background")
        {
            _onGround = true;
            _jumped = false;
            PlayerAnimator.SetTrigger("Grounded");
        }
    }
}
