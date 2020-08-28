using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class damage : MonoBehaviour
{
    private int lives = 3;
    public GameObject[] hearts;
    private AudioSource damageSound;
    private screenShake shaker;
    private ball ball;

    private void Start()
    {
        damageSound = GetComponent<AudioSource>();
        shaker = GameObject.Find("shaker").GetComponent<screenShake>();
        ball = GameObject.Find("ball").GetComponent<ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            tookDamage();
        }
    }

    private void tookDamage()
    {
        lives--;
        Destroy(hearts[lives].gameObject);
        damageSound.Play();

        if (lives <= 0)
        {
            shaker.shakeStrength = 0.8f;
            shaker.shakeDuration = 2f;
            shaker.Shake();
            InvokeRepeating("playSound", 0.5f, 0.5f);
            Invoke("gameOver", 2f);
        }
        else
        {
            ball.ResetPosition();
            ball.Invoke("Launch", 1.2f);
            shaker.Shake();
        }
    }

    private void playSound()
    {
        damageSound.Play();
    }
    private void gameOver()
    {
        CancelInvoke("playSound");
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScene("Gameover");
    }
}
