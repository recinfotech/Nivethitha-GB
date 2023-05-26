using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlueB : MonoBehaviour
{
    public Text ScoreText;
    public float Score;
    private Rigidbody2D rb;
    public float jumpforce;
    void Start()

    {
        Score = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "pipe")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
        public void UpdateScore()
    {
        Score = Score + 1f;
        ScoreText.text = Score.ToString();
    }
     







}


