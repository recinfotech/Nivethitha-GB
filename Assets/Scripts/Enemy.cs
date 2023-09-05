using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 3f;

    


    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-speed, 0); 
        //transform.Translate(Vector2.left * speed * Time.fixedDeltaTime); 
    }



}
