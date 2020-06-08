using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Animator AgentAnimator;
    public Rigidbody2D AgentRigidbody;
    public int Level;
    public PlayerProgression playerProgression;

    private int _Health = 100;
    private int _BaseXp = 100;
    private float _EnemyXpMultiplier = 1.3f;

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
        if (_Health <= 0)
        {
            playerProgression.AddXp((int)(_BaseXp * (1 - Mathf.Pow(_EnemyXpMultiplier, Level) / (1 - _EnemyXpMultiplier))));
            Destroy(this.gameObject);
        }
        AgentAnimator.SetTrigger("Hit");
        AgentRigidbody.AddForce(new Vector2(direction, 0), ForceMode2D.Impulse);
    }
}
