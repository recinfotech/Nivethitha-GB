using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))] // to move a gameobject we need to have a rigidbody.

public class Movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float speedMultiplier = 1.0f;
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; } // the other scripts can only read the direction , only this script can set its direction
    public Vector2 nextDirection { get; private set; }
    public Vector3 startingPosition { get; private set; }
    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>(); // it takes the starting position as what we give in transform.
        this.startingPosition = this.transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false;
        this.enabled = true; // gameobject  is enabled
    }

    private void Update()
    {
        if (this.nextDirection != Vector2.zero)
        {
            SetDirection(this.nextDirection);
        }
    }



    private void FixedUpdate()
    {
        Vector2 position = this.rigidbody.position; 
        Vector2 translation = this.direction * this.speed * this.speedMultiplier * Time.fixedDeltaTime;
        this.rigidbody.MovePosition(position + translation); // it access the rigidbody to move its position to new position
    }

    public void SetDirection(Vector2 direction, bool forced = false) // doubt
    {
        if (forced || !Occupied(direction)) // if not occupied
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        }
        else

        {
            this.nextDirection = direction; // if occupied 
        }
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, this.obstacleLayer);
        return hit.collider != null;
        // boxcast is positioned in the centre of an object, (moving position, scaling 75%(smaller than 1 unit, 0.0f(angle), 
        //(1.5f) to check the next tile, checks the box cast on the obstacle layer
        // Any object making contact with the boxcast can be detected and reported.
    }







}
