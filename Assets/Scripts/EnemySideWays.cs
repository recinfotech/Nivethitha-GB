using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySideWays : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
   
    public GameObject player;
    public GameObject target;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    
    public float rbspeed;
    public bool Grounded = true;
    public Animator anim;
    public Health health;
   // public PlayerHealth playerHealth;
    public CircleCollider2D circleCollider;
    public BoxCollider2D boxCollider;



    private void Awake()
    {
        health = GetComponent<Health>();
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }
    void Start()
    {

    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                // transform.RotateAround(target.transform.position, new Vector3(0, 0, -90), 10f * Time.deltaTime);
                float x = Mathf.DeltaAngle(90, 45);
                transform.RotateAround(target.transform.position, new Vector3(0, 0, -90), x * Time.deltaTime);

            }
            else
            {
                movingLeft = false;
            }
        }

        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                float x = Mathf.DeltaAngle(90, 45);
                transform.RotateAround(target.transform.position, new Vector3(0, 0, -90), x * Time.deltaTime);
            }
            else
            {
                movingLeft = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetType() == typeof(BoxCollider2D))
        {

            if (collision.gameObject.tag == "Player")
            {

                anim.SetTrigger("SquareBlast");

            }
        }
        else if (collision.collider.GetType() == typeof(CircleCollider2D))
        {
            if (collision.gameObject.tag == "Player")
            {

                GetComponent<Health>().TakeDamage(1);
                // GetComponent<PlayerHealth>().TakeDamage(1);

            }
        }

    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}

