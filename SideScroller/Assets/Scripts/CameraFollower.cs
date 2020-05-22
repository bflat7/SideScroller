using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject PlayerAgent;
    public float maxHDistance;
    public float minPosX;
    public float yOffset;

    private Vector2 velocity;
    private float hSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        hSpeed = PlayerAgent.GetComponent<PlayerController>().MoveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var playerPos = PlayerAgent.transform.position;
        if (playerPos.x - this.transform.position.x > maxHDistance || this.transform.position.x - playerPos.x > maxHDistance)
        {
            var smoothPos = Vector2.SmoothDamp(playerPos, this.transform.position, ref velocity, .003f);
            if (smoothPos.x < minPosX)
                smoothPos.x = minPosX;
            this.transform.position = new Vector3(smoothPos.x, smoothPos.y, transform.position.z);
        }

        this.transform.position = new Vector3(this.transform.position.x, PlayerAgent.transform.position.y + yOffset, this.transform.position.z);
    }
}
