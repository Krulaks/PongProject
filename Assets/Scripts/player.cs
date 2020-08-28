using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float movement;

    public float speed;
    public Rigidbody2D rbody;
    
    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Vertical");
        rbody.velocity = new Vector2(0, speed * movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PlayerBallHit();
            GameObject.Find("ball").GetComponent<ball>().IncreaseSpeed();        }
    }
}
