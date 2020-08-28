using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 currPosition;

    private float startSpeed;
    public float speed;

    public Rigidbody2D rbody;

    private AudioSource hitSound;
    

    void Start()
    {
        startPos = transform.position;
        startSpeed = speed;
        hitSound = GetComponent<AudioSource>();
        Launch();
    }

    public void ResetPosition()
    {
        transform.position = startPos;
        rbody.velocity = Vector2.zero;
    }

    public void Launch()
    {
        float x = RandomOne();
        float y = RandomOne();
        currPosition = new Vector2(x, y);
        rbody.velocity = currPosition.normalized * speed;
    }
    public void IncreaseSpeed()
    {
        speed = speed + 0.01f * startSpeed;
        currPosition = new Vector2(transform.position.x, transform.position.y);
        rbody.velocity = -currPosition.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitSound.Play();
    }

    private int RandomOne()
    {
        if (Random.Range(0, 2) == 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}