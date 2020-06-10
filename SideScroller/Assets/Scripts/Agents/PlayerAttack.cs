using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator PlayerAnimator;

    private bool _CanAttack = true;
    private bool _Blocking = false;

    public bool Blocking => _Blocking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && _CanAttack)
        {
            if (_Blocking)
                SetBlock(false);

            PlayerAnimator.SetTrigger("Attack");
            _CanAttack = false;
        }

        if (Input.GetButton("Fire2"))
        {
            SetBlock(true);
        } else if (_Blocking)
        {
            SetBlock(false);
        }

    }

    private void SetBlock(bool block)
    {
        _Blocking = block;
        PlayerAnimator.SetBool("Blocking", _Blocking);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Agent":
                Agent agentScript = collision.GetComponent<Agent>();
                agentScript.GotHit(this.transform.position.x > collision.transform.position.x ? -1 : 1);
                break;
        }
    }

    public void BufferAttack()
    {
        _CanAttack = true;
    }
}
