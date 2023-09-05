using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class EnemyFollow : MonoBehaviour
{

    public Animator anim;
   // [SerializeField] private float damage;
    public GameObject player;
    public GameObject target;
    [SerializeField] private float speed;
    public float gravity;
    private float leftEdge;
    public float jumpForce;
    public bool grounded { get; private set; }
    public bool jumping { get; private set; }
    public CircleCollider2D circleCollider;
    public BoxCollider2D boxCollider;
    private bool hit;
    public Rigidbody2D rb;
    private Vector2 velocity;
    public Health health;
    public PlayerMovement playerMovement;
   // public Health playerHealth;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        enabled = false;
    }
    private void OnBecameVisible()

    {
        enabled = true;
    }
    private void OnBecameInvisible()
    {
        enabled = false;
    }
    private void OnEnable()
    {
        rb.WakeUp();
    }
    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
        rb.Sleep();
    }


    void Start()
    {

    }
    void Update()
    {


    }

    private void FixedUpdate()
    {

        transform.RotateAround(target.transform.position, new Vector3(0, 0, 90), 100f * Time.deltaTime);

        if (target != null)
        {
            velocity.y += Physics2D.gravity.y + Time.fixedDeltaTime;
            target.transform.position = new Vector3(
            // Mathf.MoveTowards(transform.position.x, player.transform.position.x - 1, 10f * Time.deltaTime), transform.position.y, transform.position.z);
            Mathf.MoveTowards(transform.position.x, player.transform.position.x - 1, 10f * Time.deltaTime), velocity.y, transform.position.z);
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

            grounded = rb.Raycast(Vector2.down);
            Debug.Log(grounded);
            if (grounded)
            {

                GroundedMovement();
            }
            ApplyGravity();

        }
    }
    private void GroundedMovement()
    {
        
        jumping = velocity.y > 0f;
        velocity.y = Mathf.Max(velocity.y, 0f);
        velocity.y = jumpForce;
        jumping = true;
    }
    private void ApplyGravity()
    {
        // Debug.Log("ApplyGravity");
        bool falling = velocity.y < 0f;
        Debug.Log(velocity);
        float multiplier = falling ? 5f : 10f;
        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetType() == typeof(BoxCollider2D))//|| collision.GetType() == typeof(CircleCollider2D))
        {

            if (collision.gameObject.tag == "Player")
            {
                Debug.Log(collision.gameObject.tag);
                anim.SetTrigger("Blast");
               // GetComponent<PlayerMovement>().health.enabled = false;
              // GetComponent<PlayerMovement>().GetComponent<Health>().enabled = false;
            }
        }
        else if (collision.collider.GetType() == typeof(CircleCollider2D))
        {
            Debug.Log("circlecollider3");
            if (collision.gameObject.tag == "Player")
            {
                GetComponent<Health>().TakeDamage(1);
               // GetComponent<PlayerMovement>().GetComponent<Health>().TakeDamage(1);
                //  GetComponent<PlayerHealth>().TakeDamage(1);

            }
        }


    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

    





