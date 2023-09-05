using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Players")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Coyote time")]
    [SerializeField] private float CoyoteTime; //How much time the player can hang in the air before jumping
    private float CoyoteCounter; //How much time the passed since player ran off the edge

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps;
    private int JumpCounter;

    [Header("Wall Jumping")]
    [SerializeField] private float wallJumpX; //Horizontal wall jump force
    [SerializeField] private float wallJumpY; //Vertical wall jump force

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] public GameObject completedPopUp;
    [SerializeField] public GameObject failedPopUp;
    public CircleCollider2D circleCollider;
    public BoxCollider2D boxCollider;
    /*  [Header("Sounds")]
      [SerializeField] private AudioClip jumpSound;   */

    private Rigidbody2D body;
    private Animator anim;
    //private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    public Health health;
   // public PlayerHealth playerHealth;

    public GameObject Player;
    public bool follow = false;



    private void Awake()
    {
        health = GetComponent<Health>();
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");


        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(12, 12, 12);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-12, 12, 12);


        //sets animation parameters
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Grounded", isGrounded());

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();


        //Adjustable jump height
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);

        if (onWall())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }
        else
        {
            body.gravityScale = 7;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (isGrounded())
            {
                CoyoteCounter = CoyoteTime; //Reset coyote counter when on the ground
                                            //  JumpCounter = extraJumps; //Reset jump counter to extra jump value
            }
            else
                CoyoteCounter -= Time.deltaTime; //Start decreasing coyote counter when not on the ground
        }


        // wall jump logic
        /*    if (wallJumpCooldown > 0.2f)
            { 

                body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

                if (onWall() && !isGrounded())
                {
                    body.gravityScale = 0;
                    body.velocity = Vector2.zero;
                }
                else
                    body.gravityScale = 7;

                if (Input.GetKey(KeyCode.Space))
                {
                    Jump();
                    if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
                        SoundManager.instance.PlaySound(jumpSound);      
                }
            }
            else
                wallJumpCooldown += Time.deltaTime;       */
    }



    private void Jump()
    {
        if (CoyoteCounter <= 0 && !onWall() && JumpCounter <= 0) return; //If coyote counter is 0 or less and not on the wall and don't have any extra jumps don't do anything
                                                                         // SoundManager.instance.PlaySound(jumpSound);

        if (onWall())
            WallJump();
        else
        {
            if (isGrounded())
                body.velocity = new Vector2(body.velocity.x, jumpPower);
            else
            {
                //If not on the ground and coyote counter bigger than 0 do a normal jump
                if (CoyoteCounter > 0)
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
                else
                {
                    if (JumpCounter > 0) //If we have extra jumps then jump and decrease the jump counter 
                    {
                        body.velocity = new Vector2(body.velocity.x, jumpPower);
                        jumpPower--;
                    }
                }
            }
            //Reset coyote counter to 0 to avoid double jumps
            CoyoteCounter = 0;
        }
    }




    /*    if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            
           //anim.SetTrigger("jump");
        }
       else if(onWall() && !isGrounded())
       {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;
            
       }
        
    }          */


    /*  private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }         */


    private void WallJump()
    {
        body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpX, wallJumpY));
        wallJumpCooldown = 0;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("12boxcolliderone");

        // if (collision.collider.GetType()  == typeof(CircleCollider2D))
        //{
        //    Debug.Log("boxcolliderone");
        if (collision.gameObject.tag == "CircleEnemy")// && collision.GetType() == typeof(BoxCollider2D))
        {
            GetComponent<Health>().TakeDamage(1);
            //  GetComponent<EnemyFollow>().anim.SetTrigger("Blast");

        }
        //}

        //if (collision.collider.GetType() == typeof(PolygonCollider2D))
        //{
        //    Debug.Log("boxcolliderone");
        if (collision.gameObject.tag == "SquareEnemy")
        {
            Debug.Log("boxcollider");
            GetComponent<Health>().TakeDamage(1);

        }
        //}



        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("Animation");
            anim.SetTrigger("die");
            failedPopUp.SetActive(true);
            FindObjectOfType<StarHandlerPop>().starsAchieved();
        }

        if (collision.gameObject.tag == "LevelStand")
        {
            completedPopUp.SetActive(true);
            FindObjectOfType<StarHandlerPop>().starsAchieved();
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }


}



