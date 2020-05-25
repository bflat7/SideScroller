using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Animator AgentAnimator;
    public Rigidbody2D AgentRigidbody;

    private int _Health = 100;
    private int _DamageCooldown = 4;

    void Start()
    {
        
    }


    void Update()
    {
        if (_Health <= 0)
            Destroy(this.gameObject);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    switch (collision.gameObject.tag)
    //    {
    //        case "Player":
    //            _Health -= 10;
    //            AgentAnimator.SetTrigger("Hit");
    //            int normalizedX = collision.gameObject.transform.position.x > this.transform.position.x ? -1 : 1;
    //            AgentRigidbody.AddForce(new Vector2(normalizedX, 0), ForceMode2D.Impulse);
    //            break;
    //    }
    //}

    public void GotHit(int direction)
    {
        _Health -= 10;
        AgentAnimator.SetTrigger("Hit");
        AgentRigidbody.AddForce(new Vector2(direction, 0), ForceMode2D.Impulse);
    }
}
