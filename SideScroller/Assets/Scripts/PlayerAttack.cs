using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator PlayerAnimator;

    private bool _CanAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && _CanAttack)
        {
            PlayerAnimator.SetTrigger("Attack");
            _CanAttack = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // apply damage
    }

    public void BufferATtack()
    {
        Debug.Log("entered function");
        _CanAttack = true;
    }
}
