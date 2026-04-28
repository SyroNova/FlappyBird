using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float power = 2f;
    public float jump;
    private Animator animator;
    private Rigidbody2D rb;
    public float speed = 1f;
    public GameManager gameManager;
    private Transform t;
    public TMP_Text textScore;
    public int score = 0;
    public int bestScore = 0;
    bool dead = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (Input.GetButtonDown("Submit"))
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                gameManager.PlayGame();
                animator.enabled = true;
            }
            if (rb.bodyType == RigidbodyType2D.Dynamic)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, power);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //t.position = new Vector3(0, 0, 0);
        if(score > bestScore)
        {
            bestScore = score;
            gameManager.GameOverScore();
            dead = true;
        }
        score = 0;
        textScore.text = (bestScore != 0) ? score.ToString() + "(" + bestScore + ")" : score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScorePlus"))
        {
            score += 1;
            textScore.text = (bestScore != 0) ? score.ToString() + "(" + bestScore + ")" : score.ToString();
        }
        if (collision.gameObject.CompareTag("OutBounds"))
        {
            dead = true;
            gameManager.GameOverOutBounds();
        }
    }
}
