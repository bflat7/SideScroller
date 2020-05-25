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
